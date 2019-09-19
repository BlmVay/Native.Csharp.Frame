using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.EventArgs
{
    public abstract class BlmOrderArgsBase
    {
        public enum OrderType
        {

            /// <summary>
            /// 设置机器人状态
            /// </summary>
            SetState,

            /// <summary>
            /// 设置发送消息队列间歇时间
            /// </summary>
            SetSendMessageQueueIntervalTime,

            /// <summary>
            /// 设置大主人
            /// </summary>
            SetMainMaster,

            /// <summary>
            /// 添加小主人
            /// </summary>
            AddMaster,

            /// <summary>
            /// 移除小主人
            /// </summary>
            RemoveMaster,

            /// <summary>
            /// 群禁言
            /// </summary>
            GroupForbiddenWords
        }

        private readonly List<OrderType> MainMasterAuths = new List<OrderType>() {
            OrderType.AddMaster,
            OrderType.RemoveMaster,
            OrderType.SetMainMaster,
            OrderType.SetSendMessageQueueIntervalTime,
            OrderType.SetState,
            OrderType.GroupForbiddenWords
        };

        private readonly List<OrderType> MasterAuths = new List<OrderType>() {
            OrderType.GroupForbiddenWords
        };


        /// <summary>
        /// 执行类型
        /// </summary>
        public OrderType orderType;

        /// <summary>
        /// 执行权限 1:最高权限  2:普通权限
        /// </summary>
        public int auth = 2;


        /// <summary>
        /// 解析命令
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public Action AnalyticalCommand(string comm)
        {
            return ()=> { };
        }
    }
}
