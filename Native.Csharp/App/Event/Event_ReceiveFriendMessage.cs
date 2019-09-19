using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.EventArgs;
using Native.Csharp.App.Interface;
using Native.Csharp.App.DoMain;
using Native.Csharp.Tool.Json;
using Native.Csharp.Tool.Http;
namespace Native.Csharp.App.Event
{
    public class Event_ReceiveFriendMessage : IReceiveFriendMessage
    {
        private TulingChatResponseDO _tulingChatResponseDO = new TulingChatResponseDO();
        public void ReceiveFriendMessage(object sender, CqPrivateMessageEventArgs e)
        {
            Common.CqApi.AddLoger(Sdk.Cqp.Enum.LogerLevel.Debug,"MyGirl-Blm",e.Message);
            try
            {
                GlobalVariable._tulingChatRequestDO.perception.inputText.text = e.Message;
                
                Common.CqApi.SendPrivateMessage(e.FromQQ,
                    JsonTool.StringToObject<TulingChatResponseDO>(
                        HttpTool.Post(GlobalVariable.TULINGCHATBUGAPIURL,
                        GlobalVariable.
                        _tulingChatRequestDO)).
                        data.results[0].
                        values.text);
            }catch(Exception ex)
            {
                Common.CqApi.SendPrivateMessage(e.FromQQ, ex.Message);
            }
        }
    }
}
