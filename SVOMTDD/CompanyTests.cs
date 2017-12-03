using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Class;
using NHibernate.Cfg;
using DataLayer.Mapping;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace SVOMTDD
{
    [TestClass]
    public class CompanyTests
    {
        private static ISessionFactory _sessionFactory;

        protected static void BuildQueryFactory()
        {
            var config = Fluently.Configure()
             .Database(
              MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Default")).ShowSql())
              .Mappings(
              m => m.FluentMappings.AddFromAssemblyOf<CompanyMap>().AddFromAssemblyOf<User>().AddFromAssemblyOf<Vehicle>()
            ).BuildConfiguration();


            _sessionFactory = config.BuildSessionFactory();


        }

        [TestMethod]
        public void GetSingleCompany()
        {

            BuildQueryFactory();

            Company singleCompany = new Company();

            var query = "Imagination";


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
            BuildQueryFactory();

            Company singleCompany = new Company();

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
            BuildQueryFactory();

            IList<Company> singleCompany = new List<Company>();

            string query = "IMA";

            // null or empty checker
            if (!string.IsNullOrEmpty(query))
            {
                using (ISession session = _sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        // this will search for
                        singleCompany = session.QueryOver<Company>().WhereRestrictionOn(x => x.Name).IsInsensitiveLike("%" + query + "%").List();
                    }
                }
            }

            Assert.AreEqual(3, singleCompany.Count);
        }

        [TestMethod]
        public void GetCompanyusingGenerics()
        {


            Company singleCompanyWithEmployees = new Company();

            Guid query = Guid.Parse("35F97627-B0E3-4204-93FA-A82900E5234C");

            singleCompanyWithEmployees = GetSingleRecord<Company>("Id", query);

            var result = singleCompanyWithEmployees;

            Assert.AreEqual("Imagination", result.Name);

        }

        private static T GetSingleRecord<T>(string propertyName, object searchParam)
        {
            BuildQueryFactory();

            object singleItem;

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // this will search for
                    singleItem = session.CreateCriteria(typeof(T)).Add(Restrictions.Eq(propertyName, searchParam)).UniqueResult();
                }

            }


            return (T)singleItem;
        }

        [TestMethod]
        public void AddASingleCompanyAndGetTheCompany()
        {

            BuildQueryFactory();

            Company singleCompany = new Company() { Name = "MarksParts", Supplier = true, MobilePhone = 0778304453, OfficePhone = 01908457125 };
            Company CompanyReturn;

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    CompanyReturn = session.QueryOver<Company>().WhereRestrictionOn(x => x.Name).IsLike(singleCompany.Name).SingleOrDefault();
                    // this is if we know exactly what we are looking for but is not checking if the company already exists.
                    if (CompanyReturn == null)
                    {
                        session.SaveOrUpdate(singleCompany);
                        CompanyReturn = singleCompany;
                        transaction.Commit();

                    }

                    session.Flush();
                }
            }

            Assert.AreEqual("MarksParts", CompanyReturn.Name);
        }

        [TestMethod]
        public void SearchUsingOneProperty()
        {



            // when passing the property this will be passed as an object.
            long searchparam = 1525237322;
            string propertyName = "OfficePhone";

            var result = GetGenericItem<Company>(propertyName, searchparam);

            Assert.AreEqual(4, result.Count);
        }

        protected static IList<T> GetGenericItem<T>(string propertyName, object searchparam)
        {
            BuildQueryFactory();

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


        [TestMethod]
        public void GetsingleRecordandOneExtraResultUsingGenerics()
        {
            Guid query = Guid.Parse("35F97627-B0E3-4204-93FA-A82900E5234C");

            var result = GetSingleRecordAndOneRecord<Company>("Id", query, "Operatrives");


            Assert.AreEqual(1, result.Operatives.Count);
        }

        private static T GetSingleRecordAndOneRecord<T>(string propertyName, object searchParam, string SingleFetchProperty)
        {
            BuildQueryFactory();

            object singleItem;

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // this will search for
                    singleItem = session.CreateCriteria(typeof(T)).Add(Restrictions.Eq(propertyName, searchParam)).SetFetchMode(SingleFetchProperty, FetchMode.Eager) .UniqueResult();
                }

            }


            return (T)singleItem;
        }

        [TestMethod]
        public void addInsurance()
        {
            var singleCompany = new Company();
            BuildQueryFactory();
            using (ISession session = _sessionFactory.OpenSession())
            {
                //   Company singleCompany = new Company() { Name = "MarksParts", Supplier = true, MobilePhone = 0778304453, OfficePhone = 01908457125 };
                singleCompany = session.QueryOver<Company>().Where(x => x.Name == "Imagination").SingleOrDefault();
                CorprateInsurance CIns = new CorprateInsurance() { Name = "Asus", InsurancePolicynumber = "15544878663fghG665", OfficePhone = 0152565685 };
                singleCompany.Insurances.Add(null);
            }
          string update = UpdateSingleRecordWithoutRecordCheck(singleCompany);

            Assert.AreEqual("Error Null or empty Value passed to save method", update);

        }

        private static string UpdateSingleRecordWithoutRecordCheck(object SingleRecord)
        {
            BuildQueryFactory();
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
                    catch(StaleStateException ex)
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
