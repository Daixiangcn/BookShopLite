using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLite.Controllers
{
    public class StoreController : Controller
    {
        // 图书列表
        public ActionResult bookList()
        {

            List<db.Books> list = db.bll.books.getBooks();
            return View(list);
        }
        // 购书
        [HttpGet]
        public ActionResult Order(int id) {
            db.Books entity = db.bll.books.getBooks(id);
            return View(entity);
        }
        // 下单
        [HttpPost]
        public ActionResult Order(int id,string Address,int Num) {
            db.bll.orders.insert(id,Address,Num);
            return RedirectToAction("orderList");
        }
        // 订单列表
        public ActionResult orderList() {
            List<db.sv_Orders> list = db.bll.orders.getOrders();
            return View(list);
        }
    }
}