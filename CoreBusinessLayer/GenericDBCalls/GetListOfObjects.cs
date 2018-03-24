using CoreBusinessLayer.Factories;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace CoreBusinessLayer.GenericDBCalls
{
    public class GetListOfObjects : UserCompanyVehicleFactory
    {

        public IList<T> GetGenericItem<T>(string propertyName, object searchparam)
        {
            BuildCompanyUserVehicleQueryFactory();

            IList<T> CompanyListResult = new List<T>();
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (searchparam is string)
                    {
                        searchparam = "%" + searchparam + "%";

                        CompanyListResult = session.CreateCriteria(typeof(T)).Add(Restrictions.InsensitiveLike(propertyName, searchparam)).List<T>();
                    }
                    else
                    {
                        CompanyListResult = session.CreateCriteria(typeof(T)).Add(Restrictions.Gt(propertyName, searchparam) || Restrictions.Eq(propertyName, searchparam)).List<T>();
                    }
                }
            }

            return CompanyListResult;

        }

      

    }
}
