using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLite.Filters
{
    public class myErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string msg = "";
            if (filterContext.Exception != null) {
                msg += filterContext.Exception.Message;
            }
            if (filterContext.Exception.InnerException != null) {
                msg += filterContext.Exception.InnerException.Message;
            }
            filterContext.HttpContext.Session["errorMsg"] = msg;
            // 代表异常被处理
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/login/error");
        }
    }
}