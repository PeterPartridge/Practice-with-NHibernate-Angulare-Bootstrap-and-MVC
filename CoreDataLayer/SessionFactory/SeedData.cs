using CoreDataLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SessionFactory
{
    public class SeedData
    {
        private static User person;
        private static Vehicle Van;
        private static Trade Elec;
        #region Company seed data
        /// <summary>
        /// seed data for the for the Database
        /// </summary>
        /// <returns></returns>
        /// 
        #region newUser
        private void CreateUser()
        {
            person = new User
            {
                FirstName = "Bob",
                MiddleName = "",
                LastName = "Bird",
                email = "",
                DateOfBirth = DateTime.Parse("2017/01/01"),
                EmploymentDate = DateTime.Now,
                MobilePhone = 07783000343,
                OfficePhone = 05485214564874,
                Sex = " Male",
                Title = "Mr"


            };
        }
        #endregion

        #region new Van
        private void CreateVehicle()
        {
            Van = new Vehicle
            {
                LicensePlate = "TF05MPU",
                Model = "Big",
                Make = "Ford",
                MeasurmentUnit = "M",
                Milage = 100,
                PurchasePrice = 30000,
                NextMOTDate = DateTime.Now.Date.AddYears(5),
                DocumentLocation = "c:/images/Important/TF05MPU/V5C.jpg",
                TaxPaidDate = DateTime.Now,
                TaxDueDate = DateTime.Now.Date.AddYears(1),
                MaxHeight = 5.56f,
                MaxWidth = 3.5f,
                CurrentValue = 30000,
                DateOfPurchase = DateTime.Now.Date.AddDays(-6),
                DepreciationPercentage = 12.3333f,
                Year = "17"
                
            };
        }
        #endregion

        #region new Van
        private void CreateTrade()
        {
            Elec = new Trade
            {
                Name = "Electrician", Code = "EL", Description = " An electrician"
            };
        }
        #endregion

        public List<Company> CreateCompany()
        {
            CreateTrade();
            CreateUser();
            CreateVehicle();

            person.Vehicles.Add(Van);
            person.Trades.Add(Elec);

            var Comp1 = new Company
            {
                Name = "Imagination",
                Contractor = false,
                Supplier = false,
                MobilePhone = 07783000343,
                OfficePhone = 01525237322
            };

            var Comp2 = new Company
            {
                Name = "Imagination Supplies",
                Contractor = false,
                Supplier = true,
                MobilePhone = 07783000343,
                OfficePhone = 01525237322
            };
            var Comp3 = new Company
            {
                Name = "Imagination Recruitment",
                Contractor = true,
                Supplier = false,
                MobilePhone = 07783000343,
                OfficePhone = 01525237322
            };

            var adress1 = new CorprateAdress
            {
                Number = 10,
                Street = "fiction road",
                Town = "Eurica",
                City = "",
                PostCode = "IM1 3DF",

            };
            var adress2 = new CorprateAdress
            {
                Number = 33,
                Street = "fiction road",
                Town = "Eurica",
                City = "",
                PostCode = "IM1 3DF",

            };
            var adress3 = new CorprateAdress
            {
                Number = 56,
                Street = "fiction road",
                Town = "Eurica",
                City = "",
                PostCode = "IM1 3DF",

            };

            var ins1 = new CorprateInsurance
            {
                Name = "Aviva",
                InsurancePolicynumber = "tgdsfsf1233w423535",
                OfficePhone = 01234456872
            };
            var ins2 = new CorprateInsurance
            {
                Name = "Admieral",
                InsurancePolicynumber = "tg1254f1233w423535",
                OfficePhone = 01234456872
            };


            Comp1.Adresses.Add(adress1);
           Comp1. Employees.Add(person);
            Comp2.Adresses.Add(adress3);
            Comp3.Adresses.Add(adress2);
            Comp1.Insurances.Add(ins1);
            Comp3.Insurances.Add(ins2);

            List<Company> compList = new List<Company>();

            compList.Add(Comp1);
            compList.Add(Comp2);
            compList.Add(Comp3);




            return compList;
        }

        #endregion
        #region create wage
        public Wage CreateWageBand()
        {
            var wg1 = new Wage
            {
                Code = "EL1",
                Hourly = true,
                HourlyRate = 2.33f,
                
            };
            wg1. Employees.Add(person);
            return wg1;

        }
        #endregion
       

    }
}
