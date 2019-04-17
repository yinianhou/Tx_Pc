using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tx.Framework.AjaxResponse;
using Tx.Framework.Models;

namespace TxMvc.Common
{
    public enum AuthenLevel
    {
        //会员身份认证        
        Login
    }
    public class UserAuthentication : AuthorizeAttribute
    {
        public AuthenLevel Level { get; set; }
        public string Redirect { get; set; }
        /// <summary>        
        /// 机关函数        
        /// </summary>
        public UserAuthentication()
        {
            this.Level = AuthenLevel.Login;
        }
        /// <summary>        
        /// 履行前验证        
        /// </summary>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            UserSession session = HttpContext.Current.Session[BaseConfig.SESSION_USER_LOGIN_KEY] as UserSession;
            if (Controllers.BaseController.IsAJAX)
            {
                AjaxAuthentication(filterContext, session);
            }
            else
            {
                if (session == null)
                {
                    string rawUrl;
                    if (!string.IsNullOrEmpty(Redirect))
                    {
                        rawUrl = GetRoot(HttpContext.Current.Request.Url.AbsoluteUri) + Redirect;
                    }
                    else
                    {
                        rawUrl = HttpContext.Current == null ? "" : HttpContext.Current.Request.Url.AbsoluteUri;
                    }
                    filterContext.Result = new RedirectResult(string.Format("{0}?RedirectUrl={1}", "/Passport/Login", HttpUtility.UrlEncode(rawUrl)));
                }
            }
        }
        private void AjaxAuthentication(AuthorizationContext filterContext, UserSession session)
        {
            AjaxResponse reponse = new AjaxResponse();
            reponse.IsSuccess = true;
            if (session == null)
            {
                reponse.IsSuccess = false;
            }
            if (!reponse.IsSuccess)
            {
                reponse.ErrorCode = AjaxErrorCode.FAIL_UNLOGIN;
                filterContext.Result = new JsonResult() { Data = reponse };
            }
        }
        /// <summary>
        /// http://www.yundx.com/xx
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetRoot(string url)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;
            if (url.IndexOf("http://") != 0)
            {
                return url;
            }
            url = url.Substring(7);
            int index = url.IndexOf('/');
            if (index != -1)
            {
                url = url.Substring(0, index);
            }
            return "http://" + url;
        }
    }
}