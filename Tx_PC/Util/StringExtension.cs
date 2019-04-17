using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Util
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        public static string IfEmpty(this string str, string newstr)
        {
            if (str == null || str == "")
            {
                return newstr;
            }
            else
            {
                return str;
            }
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        public static string ToStringEmpty(this object obj, string newstr = "")
        {
            if (obj == null)
            {
                return newstr;
            }
            else
            {
                return obj.ToString();
            }
        }
    }
}
