using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.lib
{
    class efHelper
    {
        public static void entryUpdate(object entry,dbEntities dc) {
            dc.Entry(entry).State = System.Data.EntityState.Unchanged;
            // 表单中的元素
            List<string> list = System.Web.HttpContext.Current.Request.Form.AllKeys.ToList<string>();
            foreach (var i in entry.GetType().GetProperties())
            {
                if (list.Contains(i.Name))
                {
                    dc.Entry(entry).Property(i.Name).IsModified = true;
                }
            }
        }
    }
}
