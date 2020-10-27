using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLite.Filters
{
    public class myAuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        // 在action之前被执行
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            var actionAnony = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true) as IEnumerable<AllowAnonymousAttribute>;
            var controllerAnony = filterContext.Controller.GetType().GetCustomAttributes(typeof(AllowAnonymousAttribute), true) as IEnumerable<AllowAnonymousAttribute>;
            if ((actionAnony != null && actionAnony.Any()) || (controllerAnony != null && controllerAnony.Any()))
            {
                return;
            }
            // 未登录
            if (filterContext.HttpContext.Session["isLogin"] == null)
            {
                string url = filterContext.HttpContext.Request.RawUrl;
                filterContext.HttpContext.Session["toUrl"] = url;
                filterContext.Result = new RedirectResult("/login/index");
            }
        }
    }
}