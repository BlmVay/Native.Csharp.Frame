using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Native.Csharp.App.Utils
{
    public class MessageQueueManager
    {
        /// <summary>
        /// 构造 
        /// </summary>
        /// <param name="intervalTime">间歇时长</param>
        public MessageQueueManager(int intervalTime)
        {
            IntervalTime = intervalTime <= 0 ? 500 : intervalTime;
        }

        /// <summary>
        /// 最大队列长度
        /// </summary>
        const int MAXCOUNT = 65535;

        /// <summary>
        /// 间歇时间 ms
        /// </summary>
        public int IntervalTime { get; set; } = 1500;

        /// <summary>
        /// 消息处理者对象
        /// </summary>
        public class SendMessageHandler
        {
            /// <summary>
            /// 消息体
            /// </summary>
            public struct Message
            {
                public long NumberID;
                public string msg;
            }

            /// <summary>
            /// 消息类型
            /// </summary>
            public enum SendMsgType
            {
                /// <summary>
                /// 讨论组消息
                /// </summary>
                Discuss = 0,

                /// <summary>
                /// 私聊消息
                /// </summary>
                Private,

                /// <summary>
                /// 发送群聊消息
                /// </summary>
                Group,

                /// <summary>
                /// 发送赞
                /// </summary>
                Praise
            }

            private SendMsgType sendMsgType;

            public Message message;

            /// <summary>
            /// 构造
            /// </summary>
            /// <param name="sendMsgType">消息类型</param>
            /// <param name="message">消息</param>
            public SendMessageHandler(SendMsgType sendMsgType,Message message)
            {
                this.sendMsgType = sendMsgType;
                this.message = message;
            }

            /// <summary>
            /// 执行发送
            /// </summary>
            /// <param name="sendMsgType"></param>
            /// <param name="message"></param>
            /// <returns>结果负数为失败  正数为消息ID</returns>
            public int Send()
            {
                switch (sendMsgType)
                {
                    case SendMsgType.Discuss:
                        return Common.CqApi.SendDiscussMessage(message.NumberID, message.msg);
                    case SendMsgType.Group:
                        return Common.CqApi.SendGroupMessage(message.NumberID, message.msg);
                    case SendMsgType.Private:
                        return Common.CqApi.SendPrivateMessage(message.NumberID, message.msg);
                    case SendMsgType.Praise:
                        int.TryParse(message.msg, out int x);
                        return Common.CqApi.SendPraise(message.NumberID, x == 0 ? 5 : x);
                }
                return -1;
            }

            public override string ToString()
            {
                return $"" +
                    $"类型:{this.sendMsgType.ToString()}\n" +
                    $"目标:{this.message.NumberID.ToString()}\n" +
                    $"内容:{this.message.msg}";
            }
        }

        /// <summary>
        /// 消息队列
        /// </summary>
        private Queue<SendMessageHandler> _sendMessageHandlers = new Queue<SendMessageHandler>();

        /// <summary>
        /// 是否开始发送
        /// </summary>
        public bool Started { get;private set; } = false;

        /// <summary>
        /// 添加到队列
        /// </summary>
        /// <param name="sendMessageHandler"></param>
        /// <returns></returns>
        public bool Add(SendMessageHandler sendMessageHandler)
        {
            if (_sendMessageHandlers.Count >= MAXCOUNT)
            {
                Common.CqApi.AddFatalError($"队列已满!\n{sendMessageHandler.ToString()}");
                return false;
            }
            else
            {
                _sendMessageHandlers.Enqueue(sendMessageHandler);
                return true;
            }
        }

        /// <summary>
        /// 处理线程
        /// </summary>
        private Thread handlerQueueThread;

        /// <summary>
        /// 开始发送
        /// </summary>
        public void Start()
        {
            Started = true;
            handlerQueueThread = new Thread(new ThreadStart(() =>
            {
                while (Started)
                {
                    Thread.Sleep(IntervalTime);
                    if (_sendMessageHandlers.Count < 1)
                    {
                        continue;
                    }
                    SendMessageHandler t = _sendMessageHandlers.Dequeue();
                    if (t.Send() < 0)
                    {
                        Add(t);
                        Common.CqApi.AddFatalError($"消息发送失败!\n{t.ToString()}");
                    }
                }
            }))
            { IsBackground = true};

            handlerQueueThread.Start();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Stop()
        {
            Started = false;
            handlerQueueThread.Abort();
        }
    }
}
