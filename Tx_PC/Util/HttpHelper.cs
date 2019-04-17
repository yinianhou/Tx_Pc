using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>
    /// 请求服务
    /// </summary>
    public class HttpHelper
    {
        private static readonly HttpClient client = new HttpClient();
        /// <summary>
        /// 发送GET请求
        /// </summary>
        /// <param name="urlString">URL</param>
        /// <returns>响应字符流</returns>
        public static string Get(string urlString)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebRespones = null;
            Stream stream = null;
            string htmlString = string.Empty;
            try
            {
                httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
            }
            catch (Exception ex)
            {
                throw new Exception("建立页面请求时发生错误！", ex);
            }
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; Maxthon 2.0)";
            try
            {
                httpWebRespones = (HttpWebResponse)httpWebRequest.GetResponse();
                stream = httpWebRespones.GetResponseStream();
            }
            catch (Exception ex)
            {
                throw new Exception("接受服务器返回页面时发生错误！" + ex.ToString(), ex);
            }
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            try
            {
                htmlString = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("读取页面数据时发生错误！", ex);
            }
            //释放资源返回结果
            streamReader.Close();
            stream.Close();
            return htmlString;
        }
        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="param">参数</param>
        /// <returns>响应字符流</returns>
        public static string Post(string pasturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");
            byte[] data = encoding.GetBytes(postData);
            try
            {
                request = WebRequest.Create(pasturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                response = request.GetResponse() as HttpWebResponse;
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return "";
        }
        /// <summary>
        /// 发送POST请求哦
        /// </summary>
        /// <param name="pasturl"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Post(string pasturl, object obj)
        {
            return Post(pasturl, obj.ToString());
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="strUrlFilePath">文件网络路径</param>
        /// <param name="strLocalDirPath">文件本地路径</param>
        /// <returns></returns>
        public static bool DownLoadFile(string strUrlFilePath, string strLocalDirPath)
        {
            // 创建WebClient实例
            WebClient client = new WebClient();
            //被下载的文件名
            string fileName = strUrlFilePath.Substring(strUrlFilePath.LastIndexOf("/"));
            //另存为的绝对路径＋文件名
            string Path = strLocalDirPath + fileName;
            try
            {
                WebRequest myWebRequest = WebRequest.Create(strUrlFilePath);
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog("文件下载失败" + exp.Message);
            }
            try
            {
                client.DownloadFile(strUrlFilePath, Path);
                return true;
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog("文件下载失败" + exp.Message);
                return false;
            }
        }
    }
}