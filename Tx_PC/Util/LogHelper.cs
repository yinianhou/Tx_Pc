using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace Util
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        public static void WriteLog(string strMemo)
        {
            ExecuteWrite(strMemo);
        }
        public static void WriteLog(string strMemo, string logPath = "", bool byDateTime = true)
        {
            ExecuteWrite(strMemo, logPath, byDateTime);
        }
        public static void WriteLog(bool boolean, string logPath = "", bool byDateTime = true)
        {
            ExecuteWrite(boolean ? "Yes" : "No", logPath, byDateTime);
        }
        public static void WriteLog(object obj, string logPath = "", bool byDateTime = true)
        {
            ExecuteWrite(obj.ToString(), logPath, byDateTime);
        }
        public static void WriteLog(DataTable table, string logPath = "", bool byDateTime = true)
        {
            ExecuteWrite(JsonConvert.SerializeObject(table), logPath, byDateTime);
        }
        public static void WriteLog(DataRowCollection collection, string logPath = "", bool byDateTime = true)
        {
            DataTable table = new DataTable();
            bool first = true;
            foreach (DataRow row in collection)
            {
                if (first)
                {
                    table = row.Table;
                    first = false;
                }
                table.Rows.Add(row);
            }
            ExecuteWrite(JsonConvert.SerializeObject(table), logPath, byDateTime);
        }
        /// <summary>
        /// 具体执行的函数
        /// </summary>
        /// <param name="str"></param>
        private static void ExecuteWrite(string str, string logPath = "", bool byDateTime = true)
        {
            string directoryPath = HttpContext.Current.Server.MapPath(@"\Logs");
            if (logPath != "")
            {
                directoryPath = HttpContext.Current.Server.MapPath(@"\" + logPath);
            }
            string fileName = directoryPath + @"\log" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
            if (!byDateTime)
            {
                fileName = directoryPath + @"\log.txt";
            }
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            StreamWriter sr = null;
            try
            {
                if (!File.Exists(fileName))
                {
                    sr = File.CreateText(fileName);
                }
                else
                {
                    sr = File.AppendText(fileName);
                }
                sr.WriteLine(DateTime.Now + ": " + str);
            }
            catch (Exception ex)
            {
                sr.WriteLine(DateTime.Now + ": " + ex.ToString());
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }
    }
}