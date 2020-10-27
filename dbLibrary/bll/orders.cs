using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.bll
{
    public class orders {
        public static void insert(int bookid, string address, int num)
        {
            dbEntities db = new dbEntities();
            Orders orders = new Orders();
            orders.BookId = bookid;
            orders.Num = num;
            orders.Address = address;
            db.Orders.Add(orders);
            db.SaveChanges();
        }
        public static List<db.sv_Orders> getOrders() {
            dbEntities db = new dbEntities();
            List<sv_Orders> list = db.sv_Orders.ToList<sv_Orders>();
            return list;
        }
    }
}
