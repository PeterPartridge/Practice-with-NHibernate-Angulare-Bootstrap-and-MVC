using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLayer
{
    public class InitaliseDatabase
    {
        public void CallDBFactory()
        {
            DataLayer.SessionFactory.DatabaseFactory _db = new DataLayer.SessionFactory.DatabaseFactory();

            _db.CreateDB();
        }
    }
}
