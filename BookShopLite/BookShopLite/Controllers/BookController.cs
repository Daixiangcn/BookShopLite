using BookShopLite.Filters;
using db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLite.Controllers
{
    [OutputCache(CacheProfile ="sqlCache")]
    public class BookController : Controller
    {
        // GET: Book
        [OutputCache(Duration =60)]
        public ActionResult Index()
        {
            List<db.Books> list = db.bll.books.getBooks();
            return View(list);
        }
        [HttpGet]
        public ActionResult insert1() {
            db.Books entry = new db.Books();
            return View(entry);
        }
        [HttpPost]
        public ActionResult insert1(string AuthorName,string Title, Nullable<decimal> Price)
        {
            db.bll.books.insert1(AuthorName, Title, Price);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult insert2()
        {
            db.Books entry = new db.Books();
            return View(entry);
        }
        [HttpPost]
        public ActionResult insert2(db.Books entry)
        {
            db.bll.books.insert2(entry);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult update1(int id) {
            db.Books entry = db.bll.books.getBooks(id);
            return View(entry);
        }
        [HttpPost]
        public ActionResult update1(int id, string AuthorName, string Title, Nullable<decimal> Price) {
            db.bll.books.update1(id,AuthorName,Title,Price);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult update2(int id)
        {
            db.Books entry = db.bll.books.getBooks(id);
            return View(entry);
        }
        [HttpPost]
        public ActionResult update2(db.Books entry)
        {
            db.bll.books.update2(entry);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult update3(int id)
        {
            db.Books entry = db.bll.books.getBooks(id);
            return View(entry);
        }
        [HttpPost]
        public ActionResult update3(db.Books entry)
        {
            db.bll.books.update3(entry);
            return RedirectToAction("Index");
        }
        public ActionResult delete(int id) {
            db.bll.books.delete(id);
            return RedirectToAction("Index");
        }
        [OutputCache(CacheProfile ="myCache")]
        public ActionResult details(int id) {
            Books entry = db.bll.books.getBooks(id);
            return View(entry);
        }
    }
}