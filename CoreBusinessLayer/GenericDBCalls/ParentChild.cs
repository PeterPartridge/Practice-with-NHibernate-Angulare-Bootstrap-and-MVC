using CoreBusinessLayer.Factories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLayer.GenericDBCalls
{
   public class ParentChild : UserCompanyVehicleFactory
    {
        public string UpdateSingleRecordandChildRecord(object ParentRecord, object ChildRecord)
        {           
            string CompletionString = "";

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(ParentRecord);
                    session.SaveOrUpdate(ChildRecord);
                    try
                    {
                        transaction.Commit();
                        CompletionString = "Completed";
                    }
                    catch (StaleStateException ex)
                    {
                        CompletionString = "Error Null or empty Value passed to save method";
                        //er will be used in an error log via email or txt document.
                    }
                    session.Flush();
                }

            }

            return CompletionString;



        }
    }
}
