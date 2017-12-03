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
    public class GetSingleObject : UserCompanyVehicleFactory
    {
        #region get single record 
        /// <summary>
        /// This will get one record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="searchParam"></param>
        /// <returns></returns>
        public T GetSingleRecord<T>(string propertyName, object searchParam)
        {
            BuildCompanyUserVehicleQueryFactory();
            object singleItem;
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // this will search for a single record.
                    singleItem = session.CreateCriteria(typeof(T)).Add(Restrictions.Eq(propertyName, searchParam)).UniqueResult();
                }
            }
            return (T)singleItem;
        }
        #endregion
        #region get a single record and fetch extra set of records. 
        /// <summary>
        /// This generic call will get a single record and fetch an extra set of records linked to this object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="searchParam"></param>
        /// <param name="SingleFetchProperty"></param>
        /// <returns>Object of T</returns>
        public T GetSingleRecordAndFetchExtraRecord<T>(string propertyName, object searchParam, string SingleFetchProperty)
        {
            BuildCompanyUserVehicleQueryFactory();
            object singleItem;
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // this will search for
                    singleItem = session.CreateCriteria(typeof(T)).Add(Restrictions.Eq(propertyName, searchParam)).SetFetchMode(SingleFetchProperty, FetchMode.Eager).UniqueResult();
                }
            }
            return (T)singleItem;
        }
        #endregion
    }
}
