using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TxMvc.Common
{
    public class BaseConfig
    {
        /// <summary>
        /// 用户session
        /// </summary>
        public static readonly string SESSION_USER_LOGIN_KEY = "USER_SESSION_KEY";
        public static readonly string SESSION_PLATFORMCODE_KEY = "PLATFORMCODE_KEY";
        public static readonly string SESSION_USER_LOGIN_KEY_APP = "USER_SESSION_KEY_APP";
        public static readonly string SESSION_USER_LOGIN_CODE = "USER_SESSION_CODE";
        public static readonly string SESSION_USER_REGISTER_CODE = "USER_REGISTER_CODE";
    }
}