using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tx.Framework.WebHelp;

namespace TxMvc.Common.Pager
{
    public static class Pager
    {
        #region 创建AmazeUI分页控件
        /// <summary>
        /// 创建AmazeUI分页控件
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="centSize"></param>
        /// <returns></returns>
        public static HtmlString ShowPageNavigate(this HtmlHelper htmlHelper, int pageIndex, int pageSize, int totalCount, int centSize = 5)
        {
            StringBuilder pageHtml = new StringBuilder();
            pageHtml.Append("<div data-backend-compiled=''><ul class='am-pagination am-pagination-default am-no-layout' data-am-widget='pagination'>");
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1) //如果每页显示的条数小1
            {
                return new HtmlString("");
            }
            else if (totalCount <= pageSize) //如果记录总条数小于或等于每页显示的条数
            {
                return new HtmlString("");
            }
            String firstBtn = String.Empty;
            String lastBtn = String.Empty;
            String preBtn = String.Empty;
            String nextBtn = String.Empty;

            int pageCount = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            string queryParams = WebHelper.RemoveQueryParam(new List<string>() { "pageIndex", "pageSize" });
            if (string.IsNullOrWhiteSpace(queryParams))
            {
                queryParams = "?";
            }
            var redirectTo = htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.AbsolutePath + queryParams;

            firstBtn = String.Format("<li class='am-pagination-first'><a class='' href='{0}pageIndex={1}&pageSize={2} target=\"_self\" ' >首页</a></li>", redirectTo, 1, pageSize);

            preBtn = String.Format("<li class='am-pagination-prev'><a class='' href='javascript:return false;'onClick=\"javascript: window.location.href = '{0}pageIndex={1}&pageSize={2}'\"  >上一页</a></li>", redirectTo, pageIndex - 1, pageSize);

            lastBtn = String.Format("<li class='am-pagination-last'><a class='' href='javascript:return false;'onClick=\"javascript: window.location.href = '{0}pageIndex={1}&pageSize={2}'\" >尾页</a></li>", redirectTo, pageCount, pageSize);

            nextBtn = String.Format("<li class='am-pagination-next'><a class='' href='javascript:void(0)' onClick=\"javascript: window.location.href = '{0}pageIndex={1}&pageSize={2}'; return false;\" >下一页</a></li>", redirectTo, pageIndex + 1, pageSize);

            if (pageIndex <= 1)
            {
                firstBtn = String.Format("<li class='am-pagination-first am-disabled'><a class='' href='javascript:void(0);'>首页</a></li>");
                preBtn = String.Format("<li class='am-pagination-prev am-disabled'><a class='' href='javascript:void(0);'>上一页</a></li>");
            }
            if (pageIndex >= pageCount)
            {
                lastBtn = String.Format("<li class='am-pagination-last am-disabled'><a class='' href='javascript:void(0);'>尾页</a></li>");
                nextBtn = String.Format("<li class='am-pagination-next am-disabled'><a class='' href='javascript:void(0);'>下一页</a></li>");
            }

            int firstNum = pageIndex - (centSize / 2); //中间开始的页码
            if (pageIndex < centSize)
            {
                firstNum = 2;
            }

            int lastNum = pageIndex + centSize - ((centSize / 2) + 1); //中间结束的页码

            if (lastNum >= pageCount)
            {
                lastNum = pageCount - 1;
            }

            pageHtml.Append(firstBtn + preBtn);

            if (pageIndex >= centSize)
            {
                pageHtml.Append("<li><span>...</span></li>");
            }

            for (int i = firstNum - 1; i <= lastNum + 1; i++)
            {
                if (i == pageIndex)
                {
                    pageHtml.Append("<li class='am-active'><a class='am-active' href='#'>" + i + "</a></li>");
                }
                else
                {
                    pageHtml.AppendFormat("<li class=''><a class='' href='{0}pageIndex={1}&pageSize={2}'>{1}</a></li>", redirectTo, i, pageSize);
                }
            }

            if (pageCount - pageIndex > centSize - ((centSize / 2)))
            {
                pageHtml.Append("<li><span>...</span></li>");
            }

            pageHtml.Append(nextBtn + lastBtn);

            pageHtml.Append("<span><input id='Pagination-pageIndex' style='height:38px; width:85px; border: 1px solid #ddd;margin-bottom: 5px;' type='text' class=''/></span>");
            pageHtml.AppendFormat("<li><a href=\"javascript:window.location='{0}pageIndex={1}&pageSize={2}'\">Go</a></li>", redirectTo, "'+document.getElementById('Pagination-pageIndex').value+'", pageSize);

            pageHtml.Append("<span>共" + totalCount + "条记录</span>");
            pageHtml.Append("&nbsp;&nbsp;");
            pageHtml.Append("<span>共" + pageCount + "页</span>");

            pageHtml.Append("</ul></div>");

            return new HtmlString(pageHtml.ToString());
        }
        #endregion
    }
}
