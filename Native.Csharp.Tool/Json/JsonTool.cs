using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Native.Csharp.Tool.Json
{

    /// <summary>
    /// json工具
    /// </summary>
    public class JsonTool
    {
        /// <summary>
        /// 对象转json数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToString(object obj)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                return "ERROR";
            }
        }



        /// <summary>
        /// json数据转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static T StringToObject<T>(String jsonData)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
