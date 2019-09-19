using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
namespace Native.Csharp.Tool.Http
{
	/// <summary>
	/// Http 工具类
	/// </summary>
	public static class HttpTool
	{
		/// <summary>
		/// 使用默认编码对 URL 进行编码
		/// </summary>
		/// <param name="url">要编码的地址</param>
		/// <returns>编码后的地址</returns>
		public static string UrlEncode (string url)
		{
			return HttpUtility.UrlEncode (url);
		}
		
		/// <summary>
		/// 使用指定的编码 <see cref="Encoding"/> 对 URL 进行编码
		/// </summary>
		/// <param name="url">要编码的地址</param>
		/// <param name="encoding">编码类型</param>
		/// <returns>编码后的地址</returns>
		public static string UrlEncode (string url, Encoding encoding)
		{
			return HttpUtility.UrlEncode (url, encoding);
		}
		
		/// <summary>
		/// 使用默认编码对 URL 进行解码
		/// </summary>
		/// <param name="url">要解码的地址</param>
		/// <returns>编码后的地址</returns>
		public static string UrlDecode (string url)
		{
			return HttpUtility.UrlDecode (url);
		}
		
		/// <summary>
		/// 使用指定的编码 <see cref="Encoding"/> 对 URL 进行解码
		/// </summary>
		/// <param name="url">要解码的地址</param>
		/// <param name="encoding">编码类型</param>
		/// <returns>编码后的地址</returns>
		public static string UrlDecode (string url, Encoding encoding)
		{
			return HttpUtility.UrlDecode (url, encoding);
		}



        /// <summary>
        /// Post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataObj"></param>
        /// <returns></returns>
        public static string Post(string url,object postDataObj)
        {
            string result = "";
            string postData = Json.JsonTool.ObjectToString(postDataObj);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";

            req.Timeout = 5800;//设置请求超时时间，单位为毫秒

            req.ContentType = "application/json";

            byte[] data = Encoding.UTF8.GetBytes(postData);

            req.ContentLength = data.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
	}
}
