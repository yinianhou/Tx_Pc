using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tx.Framework.WebHelp
{
   public  class WebHelper
    {
        /// <summary>
        /// 移出query参数中的某个参数
        /// </summary>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static string RemoveQueryParam(List<string> parms)
        {
            string querys = HttpContext.Current.Request.Url.Query.Replace("?", string.Empty);
            List<string> list = ListHelper<string>.StrToList(querys, '&');
            if (list.Count < 1)
                return "";
            foreach (var parm in parms)
            {
                foreach (string p in list)
                {
                    if (p.Contains(parm))
                    {
                        list.Remove(p);
                        break;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("?");
            foreach (string q in list)
            {
                sb.Append(q + "&");
            }
            return sb.ToString();
        }
    }
}
