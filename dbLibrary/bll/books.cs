using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.bll
{
    public class books
    {
        public static List<db.Books> getBooks() {
            dbEntities db = new dbEntities();
            List<Books> list = db.Books.ToList<Books>();
            return list;
        }
        public static db.Books getBooks(int id) {
            dbEntities db = new dbEntities();
            Books entry = db.Books.SingleOrDefault(b => b.BookId == id);
            return entry;
        }
        public static void insert1(string AuthorName, string Title, Nullable<decimal> Price)
        {
            dbEntities dc = new dbEntities();
            Books entry = new Books();
            entry.AuthorName = AuthorName;
            entry.Title = Title;
            entry.Price = Price;
            dc.Books.Add(entry);
            dc.SaveChanges();
        }
        public static void insert2(db.Books entry)
        {
            dbEntities dc = new dbEntities();
            dc.Books.Add(entry);
            dc.SaveChanges();
        }
        public static void update1(int id,string AuthorName, string Title, Nullable<decimal> Price) {
            dbEntities dc = new dbEntities();
            Books entry = dc.Books.Single(b=>b.BookId==id);
            if (entry!=null) {
                entry.AuthorName = AuthorName;
                entry.Title = Title;
                entry.Price = Price;
                dc.SaveChanges();
            }
        }
        public static void update2(Books entry)
        {
            dbEntities dc = new dbEntities();
            dc.Entry<Books>(entry).State = System.Data.EntityState.Modified;
            dc.SaveChanges();
        }
        public static void update3(Books entry)
        {
            dbEntities dc = new dbEntities();
            db.lib.efHelper.entryUpdate(entry, dc);
            dc.SaveChanges();
        }
        public static void delete(int id) {
            dbEntities dc = new dbEntities();
            Books entry = dc.Books.SingleOrDefault(b=>b.BookId == id);
            if (entry != null) {
                dc.Books.Remove(entry);
                dc.SaveChanges();
            }
        }
        public static void details(int id) { 
        
        }
    }
}
