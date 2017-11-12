using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Class;
using NHibernate.Cfg;
using DataLayer.Mapping;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System.Collections.Generic;

namespace SVOMTDD
{
    [TestClass]
    public class UnitTest1
    {
        private static ISessionFactory _sessionFactory;

        protected static Configuration BuildQueryFactory()
        {
            var config = Fluently.Configure()
             .Database(
              MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Default")).ShowSql())
              .Mappings(
              m => m.FluentMappings.AddFromAssemblyOf<CompanyMap>().AddFromAssemblyOf<User>().AddFromAssemblyOf<Vehicle>()
            ).BuildConfiguration();


            return config;
        }

        [TestMethod]
        public void GetSingleCompany()
        {


            Company singleCompany = new Company();

            Configuration config = BuildQueryFactory();

            var query = "Imagination";

            _sessionFactory = config.BuildSessionFactory();


            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    // this is if we know exactly what we are looking for
                    singleCompany = session.QueryOver<Company>().Where(x => x.Name == query).SingleOrDefault();

                }
            }

            Assert.AreEqual("Imagination", singleCompany.Name);
        }


        [TestMethod]
        public void passingANullIntoASingleSearch()
        {

            Company singleCompany = new Company();
            Configuration config = BuildQueryFactory();
            _sessionFactory = config.BuildSessionFactory();
            string query = null;

            // null or empty checker
            if (!string.IsNullOrEmpty(query))
            {
                using (ISession session = _sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {

                        // this is if we know exactly what we are looking for
                        singleCompany = session.QueryOver<Company>().Where(x => x.Name == query).SingleOrDefault();
                    }
                }
            }

            Assert.IsNull(singleCompany.Name);

        }

        [TestMethod]
        public void SearchForCompanyContaining()
        {
            IList<Company> singleCompany = new List<Company>();
            Configuration config = BuildQueryFactory();
            _sessionFactory = config.BuildSessionFactory();
            string query = "sup";

            // null or empty checker
            if (!string.IsNullOrEmpty(query))
            {
                using (ISession session = _sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {

                        // this will search for
                        singleCompany = session.QueryOver<T>().WhereRestrictionOn(x => x.Name).IsLike("%" + query + "%").List();
                    }
                }
            }

            Assert.AreEqual(1, singleCompany.Count);
        }

    }
}
