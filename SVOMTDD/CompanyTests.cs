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

        protected static IList<T> GetGenericItem<T>(string propertyName, object searchparam, bool FindAll = true)
        {
            BuildQueryFactory();

            IList<T> CompanyListResult = new List<T>();
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (searchparam is string)
                    {
                        searchparam = FindAll == true ? "%" + searchparam + "%" : searchparam;

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


            Assert.AreEqual(1, result. Employees.Count);
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
                    singleItem = session.CreateCriteria(typeof(T)).Add(Restrictions.Eq(propertyName, searchParam)).SetFetchMode(SingleFetchProperty, FetchMode.Eager).UniqueResult();
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
               singleCompany.Insurances.Add(CIns);

               
            }
            string update = UpdateSingleRecordWithoutRecordCheck(singleCompany);

            Assert.AreEqual("Error Null or empty Value passed to save method", update);

        }

        [TestMethod]
        public void addPersonAndVehicle()
        {
            var singleCompany = new Company();
            BuildQueryFactory();
            using (ISession session = _sessionFactory.OpenSession())
            {
                //   Company singleCompany = new Company() { Name = "MarksParts", Supplier = true, MobilePhone = 0778304453, OfficePhone = 01908457125 };
                singleCompany = session.QueryOver<Company>().Where(x => x.Name == "Imagination").SingleOrDefault();
                User CIns = new User() { FirstName = "Martin", LastName = "Davies", OfficePhone = 01908564525,
                    DateOfBirth = DateTime.Parse("02/01/2001"), email = "Martin.Davies@Imagination.org.uk",
                    EmploymentDate = DateTime.Parse("2017/12/05"), MiddleName ="Jules", PreferredName ="Marty"
                };

                Vehicle veh = new Vehicle()
                {
                    Make = "Ford",
                    Model = "Transit",
                    CurrentValue = 2617.23f,
                    DocumentLocation = "At head office",
                    DateOfPurchase = DateTime.Now,
                    ExpectedYearsOfService = 25,
                    Milage = 4560,
                    NextMOTDate = DateTime.Now.AddYears(1),
                    LicensePlate = "TF09 JUY"
                };

                CIns.Vehicles.Add(veh);
                singleCompany.Employees.Add(CIns);
            }
           // string update = UpdateSingleRecordandChildRecords(singleCompany);

        //    Assert.AreEqual("Completed", update);

        }
         [TestMethod]
        public void addWage()
        {
           
            BuildQueryFactory();

            Wage newWage = new Wage() { Code = "MG01", Salery = true, YearlyRate = 30000 };
            User singlePerson;


            using (ISession session = _sessionFactory.OpenSession())
            {
                singlePerson = session.QueryOver<User>().Where(x => x.Id == Guid.Parse("520B4198-CE5D-4A24-BFD3-A8440122C572")).SingleOrDefault();

                singlePerson.Wages = newWage;

                


            }
            var update = UpdateSingleRecordandChildRecords(newWage, singlePerson);
             

            Assert.AreEqual("Completed", update);

        }

        [TestMethod]
        public void addCompanyWithChck()
        {
            var singleCompany = new Company();
            BuildQueryFactory();
            using (ISession session = _sessionFactory.OpenSession())
            {
                //singleCompany = new Company() { Name = "MarksBurgers", Supplier = true, MobilePhone = 0778304453, OfficePhone = 01908457125 };
                singleCompany = session.QueryOver<Company>().Where(x => x.Name == "Imagination").SingleOrDefault();

            }
            string update = UpdateSingleRecordWithRecordCheck<Company>("Name", singleCompany.Name, singleCompany);


            Assert.AreEqual("Completed", update);

        }

        private static string UpdateSingleRecordWithoutRecordCheck(object SingleRecord)
        {
            BuildQueryFactory();
            string CompletionString = "";

            var RecordCheck = GetGenericItem<Company>("Name", SingleRecord);

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

        private static string UpdateSingleRecordWithRecordCheck<T>(string SearchProp, object SingleRecord, T RecordToSave)
        {
            BuildQueryFactory();
            string CompletionString = "";

            IList<T> RecordCheck = GetGenericItem<T>(SearchProp, SingleRecord);

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // this will search for
                    if (!RecordCheck.Equals(RecordToSave))
                    {
                        session.SaveAsync(SingleRecord);

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

                    }
                    else
                    {
                        CompletionString = "This record already exists on the system.";
                    }
                    session.Flush();
                }

            }

            return CompletionString;
        }

        private static string UpdateSingleRecordandChildRecords(object ParentRecord, object ChildRecord)
        {

            BuildQueryFactory();
            string CompletionString = "";

           using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // this will search for

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



        [TestMethod]
        public void DeleteSingleRecord()
        {
            IList<Company> singleCompany = new List<Company>();
            BuildQueryFactory();
            using (ISession session = _sessionFactory.OpenSession())
            {
                //   Company singleCompany = new Company() { Name = "MarksParts", Supplier = true, MobilePhone = 0778304453, OfficePhone = 01908457125 };
                singleCompany = session.QueryOver<Company>().Where(x => x.Name == "MarksParts").List<Company>();
            }

         var update = DeleteSingleRecord(singleCompany[1]);

            Assert.AreEqual("Completed", update);
        }



        private static string DeleteSingleRecord(object ParentRecord)
        {

            BuildQueryFactory();
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
