using BusinessLayer.Factories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.GenericDBCalls
{
   public class DeleteSingleObject : UserCompanyVehicleFactory
    {
        public string DeleteSingleRecord(object ParentRecord)
        {
           string CompletionString = "";

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // this will search for

                    session.Delete(ParentRecord);
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
