using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.DoMain;
using Native.Csharp.App.EventArgs;
using Native.Csharp.App.Interface;
using Native.Csharp.Tool.Http;
using Native.Csharp.Tool.Json;

namespace Native.Csharp.App.Event
{
    public class Event_ReceiveGroupMessage : IReceiveGroupMessage
    {
        private Dictionary<long, string> groups = new Dictionary<long, string>() {
            { 794580984 , "102"},
            { 691038312, "天天有券?天天吃鸡!" }
        };
        public void ReceiveGroupMessage(object sender, CqGroupMessageEventArgs e)
        {
            //执行命令模式
            if (GlobalVariable.Masters.Contains(e.FromQQ) && e.Message[0] == '#')
            {

            }

            if (groups.ContainsKey(e.FromGroup))
            {
                try
                {
                    GlobalVariable._tulingChatRequestDO.perception.inputText.text = e.Message;

                    Common.CqApi.SendGroupMessage(e.FromGroup,
                        JsonTool.StringToObject<TulingChatResponseDO>(
                            HttpTool.Post(GlobalVariable.TULINGCHATBUGAPIURL,
                            GlobalVariable.
                            _tulingChatRequestDO)).
                            data.results[0].
                            values.text);
                }
                catch (Exception ex)
                {
                    Common.CqApi.SendPrivateMessage(1259935112, JsonTool.ObjectToString(new Dictionary<string, string>() {
                        { "标题:","群聊系统异常\n" },
                        { "异常信息",ex.Message + "\n" },
                        { "群号:" ,e.FromGroup.ToString() + "\n"},
                        { "触发异常的消息:",e.Message + "\n"},
                        { "时间:",DateTime.UtcNow.ToString() }
                    }));
                }
            }
        }

        private void ExecutiveOrder()
        {

        }
    }
}
