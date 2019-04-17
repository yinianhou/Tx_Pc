using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tx.Framework.WebHelp
{
   public class ListHelper<T>
    {
        #region 字符串转化为泛型集合
        /// <summary>
        /// 字符串转化为泛型集合
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="splitstr">要分割的字符</param>
        /// <returns></returns>
        public static List<T> StrToList(string str, char splitstr)
        {
            List<T> list = new List<T>();
            if (string.IsNullOrEmpty(str))
            {
                return list;
            }
            string[] strarray = str.Split(splitstr);
            foreach (string s in strarray)
            {
                if (s != "")
                    list.Add((T)Convert.ChangeType(s, typeof(T)));
            }
            return list;
        }
        /// <summary>
        /// 字符串转化为泛型集合
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static List<T> StrToList(string str)
        {
            return StrToList(str, ',');
        }
        #endregion

        /// <summary>
        /// 转换几个中所有元素的类型
        /// </summary>
        /// <typeparam name="TO"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<TO> ConvertListType<TO>(List<T> list)
        {
            if (list == null)
            {
                return null;
            }
            List<TO> newlist = new List<TO>();
            foreach (T t in list)
            {
                newlist.Add((TO)Convert.ChangeType(t, typeof(TO)));
            }
            return newlist;
        }
    }
}
