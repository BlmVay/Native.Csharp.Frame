using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.DoMain
{
    public class TulingChatRequestDO
    {
        /// <summary>
        /// 
        /// </summary>
        public perception perception { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public userInfo userInfo { get; set; }
    }

    public class inputText
    {
        /// <summary>
        /// 测试文本1
        /// </summary>
        public string text { get; set; }
    }

    public class perception
    {
        /// <summary>
        /// 
        /// </summary>
        public inputText inputText { get; set; }
    }

    public class userInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }

        public string apiKey { get; set; }
    }

}
