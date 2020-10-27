using BookShopLite.Filters;
using System.Web;
using System.Web.Mvc;

namespace BookShopLite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new myErrorAttribute());
            filters.Add(new myAuthAttribute());
            //filters.Add(new myActionAttribute());
        }
    }
}
