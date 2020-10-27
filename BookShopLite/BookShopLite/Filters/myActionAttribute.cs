using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLite.Filters
{
    public class myActionAttribute : FilterAttribute, IActionFilter,IResultFilter
    {
        private Stopwatch timer;
        // Action执行+视图渲染时间
        // Action执行后
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
        // Action执行前
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = new Stopwatch();
            timer.Start();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write("时间：" + timer.ElapsedMilliseconds);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            
        }
    }
}