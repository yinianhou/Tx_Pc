using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>
    /// DB扩展
    /// </summary>
    public static class DBExtension
    {
        /// <summary>
        /// 获得第一行，若不是则空
        /// </summary>
        /// <param name="table">表</param>
        /// <returns>表的第一行</returns>
        public static DataRow FirstRow(this DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            else
            {
                return null;
            }
        }
        public static string IfEmpty(this object obj, string newstr)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return newstr;
            }
            else
            {
                string str = obj.ToString();
                if (str != "")
                {
                    return str;
                }
                else
                {
                    return newstr;
                }
            }
        }
        public static string IfEmpty(this JValue obj, string newstr)
        {
            return IfEmpty(obj.ToString(), newstr);
        }
        public static int IfEmpty(this object obj, int newint)
        {
            int _flag = newint;
            if (int.TryParse(obj.IfEmpty(""), out _flag))
            {
                return _flag;
            }
            else
            {
                return newint;
            }
        }
        public static float IfEmpty(this object obj, float newfloat)
        {
            float _flag = newfloat;
            if (float.TryParse(obj.IfEmpty("nan"), out _flag))
            {
                return _flag;
            }
            else
            {
                return newfloat;
            }
        }
        public static bool IfEmpty(this object obj, bool newBoolean)
        {
            if (obj == DBNull.Value)
            {
                return newBoolean;
            }
            bool _flag = newBoolean;
            if (bool.TryParse(obj.IfEmpty("nan"), out _flag))
            {
                return _flag;
            }
            else
            {
                return newBoolean;
            }
        }
        public static DateTime? IfEmptyDateTime(this object obj, DateTime? datetime = null)
        {
            if (obj == DBNull.Value)
            {
                return datetime;
            }
            DateTime dt;
            if (DateTime.TryParse(obj.IfEmpty(""), out dt))
            {
                return dt;
            }
            else
            {
                return datetime;
            }
        }
    }
}