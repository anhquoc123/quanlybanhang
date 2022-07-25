using DoAn.App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.DAO
{
    public class BaseDAO
    {
        public DoChoiEntities db;

        public BaseDAO()
        {
            db = new DoChoiEntities();
        }

        public bool SaveToDb()
        {
            try
            {
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
