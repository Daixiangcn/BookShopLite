using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLite.Controllers
{
    public class ActionResultController : Controller
    {
        // GET: ActionResult
        public ActionResult Index()
        {
            // 方式1
            //return new RedirectResult("/ActionResult/BookList1");
            // 方式2
            //return RedirectToAction("BookList1","ActionResult");
            return View();
        }
        // 20元以内的书
        [ChildActionOnly]
        public PartialViewResult BookList1() {
            List<db.Books> list = db.bll.books.getBookList1();
            return PartialView(list);
        }
        // 20元以外的书
        [ChildActionOnly]
        public PartialViewResult BookList2()
        {
            List<db.Books> list = db.bll.books.getBookList2();
            return PartialView(list);
        }
        public ContentResult Css(string color) {
            if (color == "red") {
                return Content("body{color:red}","text/css");
            }
            if (color == "blue")
            {
                return Content("body{color:blue}", "text/css");
            }
            return Content("body{color:black}", "text/css");
        }
        public FileResult Download() {
            return File(Server.MapPath("~/test.txt"),"text/plain","我的文件.txt");
        }
        public JsonResult Json1() {
            var p = new
            {
                Name = "小王",
                age = 12,
                parent = new[] {
                    new { Name = "小王父亲",age = 41},
                    new { Name = "小王母亲",age = 40}
                }
            };
            return Json(p,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Json2()
        {
            var p = db.bll.books.getBooks();
            return Json(p, JsonRequestBehavior.AllowGet);
        }
        public JavaScriptResult Js() {
            return JavaScript("alert('123')");
        }
    }
}