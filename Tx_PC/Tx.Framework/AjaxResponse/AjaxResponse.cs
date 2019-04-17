using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tx.Framework.AjaxResponse
{
    [Serializable]
    public class AjaxResponse
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public string ErrorCode { get; set; }
        public object Data { get; set; }
        public AjaxResponse()
        {
            this.IsSuccess = true;
        }
    }
    public struct AjaxErrorCode
    {
        /// <summary>
        /// 未登陆
        /// </summary>
        public static string FAIL_UNLOGIN = "00";
        /// <summary>
        /// 无权限
        /// </summary>
        public static string FAIL_UNAUTH = "01";
        public static string FAIL_EXCEPTION = "99";
    }
}
