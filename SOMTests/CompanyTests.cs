using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using DataLayer.Class;
using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using DataLayer.Mapping;

namespace SOMTests
{
    [TestClass]
    public class CompanyTests
    {
        [TestMethod]
        public void GetSingleCompany()
        {
            var config = Fluently.Configure()
                     .Database(
                      MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Default")))
                      .Mappings(
                      m => m.FluentMappings.AddFromAssemblyOf<CompanyMap>()
                    ).BuildConfiguration();

            Company singleCompany;

           var _sessionFactory = config.BuildSessionFactory();

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var Transaction = session.BeginTransaction())
                {
                    singleCompany = session.QueryOver<Company>().Where(x => x.Name.Contains("CompanyA")).SingleOrDefault();
                    Transaction.Commit();
                }
            }

            Assert.AreEqual("Company A", singleCompany.Name);
        }
    }
}
