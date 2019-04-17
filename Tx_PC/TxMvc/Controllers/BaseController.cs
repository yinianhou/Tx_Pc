using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Tx.Framework.AjaxResponse;
using Tx.Framework.Log;
using Tx.Framework.Models;
using TxMvc.Common;

namespace TxMvc.Controllers
{
    public class BaseController : Controller
    {
        private Logger logger = Logger.CreateLogger(typeof(BaseController));
        protected virtual string ErrorView
        {
            get { return "~/Views/Shared/Error.cshtml"; }
        }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (CurrentUser != null)
            {
                CallContext.LogicalSetData(DefaultAttribute.USER_INDETITY, CurrentUser.UserId);
                CallContext.LogicalSetData(DefaultAttribute.USER_NAME, CurrentUser.UserName);
            }
            CallContext.LogicalSetData(DefaultAttribute.USER_IP, Request != null ? Request.UserHostAddress : "");
        }

        public JsonResult AjaxJson()
        {
            return AjaxJson(null);
        }
        public JsonResult AjaxJson(object data)
        {
            AjaxResponse reponse;
            if (data is AjaxResponse)
            {
                reponse = data as AjaxResponse;
            }
            else
            {
                reponse = new AjaxResponse();
                reponse.Data = data;
            }
            return Json(reponse, JsonRequestBehavior.AllowGet);
        }
        #region  暂时不用
        ////public JsonResult PagerJson(PageResult result)
        ////{
        ////    return Json(new { count = result.PagingInfo.TotalCount, data = result.List, code = 0, msg = "" }, JsonRequestBehavior.AllowGet);
        ////}
        ////public JsonResult PagerJson(IList li)
        ////{
        ////    return Json(new { count = li.Count, data = li, code = 0, msg = "" }, JsonRequestBehavior.AllowGet);
        ////}

        ////public JsonResult PagerJson(QueryResult result)
        ////{
        ////    return Json(new { count = result.PagingInfo.TotalCount, data = result.List, code = 0, msg = "" }, JsonRequestBehavior.AllowGet);
        ////}
        ////public JsonResult PagerJson(IList li)
        ////{
        ////    return Json(new { count = li.Count, data = li, code = 0, msg = "" }, JsonRequestBehavior.AllowGet);
        ////} 
        #endregion
        protected override void OnException(ExceptionContext filterContext)
        {
            // 标记异常已处理
            filterContext.ExceptionHandled = true;
            logger.Warn("App_Error"+ filterContext.Exception);
            if (IsAJAX)//异步
            {
                AjaxResponse reponse = new AjaxResponse();
                reponse.IsSuccess = false;
                reponse.ErrorCode = AjaxErrorCode.FAIL_EXCEPTION;
                reponse.Error = GetError(filterContext.Exception);
                if (IsAJAXFILE)//附件只能返回文本
                {
                    filterContext.Result = Content(Tx.Framework.Extension.JsonHelper.ToJson<AjaxResponse>(reponse));
                }
                else
                {
                    filterContext.Result = Json(reponse);
                }
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.HttpContext.Response.StatusDescription = "OK";
            }
            else
            {
                // 跳转到错误页
                ViewBag.Exception = filterContext.Exception;
                filterContext.Result = View(ErrorView, filterContext.Exception);
            }
        }
        /// <summary>
        /// 异步返回错误信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected string GetError(System.Exception ex)
        {
            logger.Warn("App_Error"+ex);
            bool isApplyError = false;
            string message = string.Empty;
            do
            {
                if (ex is System.Reflection.TargetInvocationException)
                {

                }
                else if (ex is ApplicationException)
                {
                    isApplyError = true;
                    message = ex.Message;
                    break;
                }
                if (ex.InnerException != null)
                    ex = ex.InnerException;
            }
            while (ex.InnerException != null);
            if (isApplyError)
            {
                return message;
            }
            else
            {
                return "系统错误,请联系客服人员";
            }
        }
        public static bool IsAJAX
        {
            get
            {
                HttpContext context = System.Web.HttpContext.Current;
                if (context != null && !string.IsNullOrEmpty(context.Request.Headers["X-Requested-With"]))
                {
                    return true;
                }
                if (context != null && !string.IsNullOrEmpty(context.Request.Headers["AjaxRequest"]))
                {
                    return true;
                }
                return false;
            }
        }
        public static bool IsAJAXFILE
        {
            get
            {
                HttpContext context = System.Web.HttpContext.Current;
                if (context != null && context.Request["AjaxFile"] == "1")
                {
                    return true;
                }
                return false;
            }
        }

        private UserSession _currentUser;
        public UserSession CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    _currentUser = Session[BaseConfig.SESSION_USER_LOGIN_KEY] as UserSession;
                }
                //if (_currentUser == null)
                //{
                //    UserSession session = new UserSession();
                //    session.UserId = "Test";
                //    session.UserName = "Test";
                //    base.Session[BaseConfig.SESSION_USER_LOGIN_KEY] = session;
                //}
                return _currentUser;
            }
        }
    }
}