using BusinessLayer.Factories;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.GenericDBCalls
{
    public class UpdateSingleObject : UserCompanyVehicleFactory
    {
        /// <summary>
        /// This will update a record but will not chjeck to see if the record already exists on the database.
        /// Duplicate checkes will need to be run before data is passed to this method.
        /// </summary>
        /// <param name="SingleRecord"></param>
        /// <returns></returns>
        public string SaveOrUpdateSingleRecordWithoutRecordCheck(object SingleRecord)
        {
            
            string CompletionString = "";
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // this will search for

                    session.SaveOrUpdate(SingleRecord);

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
