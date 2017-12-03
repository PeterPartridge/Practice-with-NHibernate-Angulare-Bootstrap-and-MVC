using BusinessLayer.Factories;
using DataLayer.Class;
using DataLayer.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.GenericDBCalls
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
