using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.DoMain
{

    public class TulingChatResponseDO
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public data data { get; set; }
    }

    public class robotEmotion
    {
        /// <summary>
        /// 
        /// </summary>
        public int a { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int d { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int emotionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int p { get; set; }
    }

    public class userEmotion
    {
        /// <summary>
        /// 
        /// </summary>
        public int a { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int d { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int emotionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int p { get; set; }
    }

    public class emotion
    {
        /// <summary>
        /// 
        /// </summary>
        public robotEmotion robotEmotion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public userEmotion userEmotion { get; set; }
    }

    public class intent
    {
        /// <summary>
        /// 
        /// </summary>
        public string actionName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string intentName { get; set; }
    }

    public class values
    {
        /// <summary>
        /// 笑得如此开怀
        /// </summary>
        public string text { get; set; }
    }

    public class resultsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int groupType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string resultType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public values values { get; set; }
    }

    public class data
    {
        /// <summary>
        /// 
        /// </summary>
        public emotion emotion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public intent intent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<resultsItem> results { get; set; }
    }
}
