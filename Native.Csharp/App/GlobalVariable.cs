using Native.Csharp.App.DoMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App
{
    public class GlobalVariable
    {

        /// <summary>
        /// 接入模式
        /// </summary>
        public enum APImode
        {
            test,
            formal
        }

        /// <summary>
        /// 正常接口模式URL
        /// </summary>
        public const string TULINGCHATAIAPIURL = "http://openapi.tuling123.com/openapi/api/v2";

        /// <summary>
        /// 图灵apikey
        /// </summary>
        public static Dictionary<string,string> apikeys;

        /// <summary>
        /// 大主人
        /// </summary>
        public static long MainMaster { get; set; } = 1259935112;

        /// <summary>
        /// 主人们
        /// </summary>
        public static List<long> Masters { get; set; } = new List<long> { 1259935112 };

        /// <summary>
        /// 图灵机器人官网测试接口 
        /// </summary>
        //public const string TULINGCHATBUGAPIURL = "http://www.tuling123.com/robot-chat/robot/chat/514733/vlcj?geetest_challenge=&geetest_validate=&geetest_seccode=";
        public const string TULINGCHATBUGAPIURL = "http://www.tuling123.com/robot-chat/robot/chat/590204/YcNj?geetest_challenge=&geetest_validate=&geetest_seccode=";

        /// <summary>
        /// 图灵聊天请求实体
        /// </summary>
        public static TulingChatRequestDO _tulingChatRequestDO = new TulingChatRequestDO()
        {
            perception = new perception()
            {
                inputText = new inputText()
            },
            userInfo = new userInfo()
            {
                userId = "Blm"
            }
        };
    }
}
