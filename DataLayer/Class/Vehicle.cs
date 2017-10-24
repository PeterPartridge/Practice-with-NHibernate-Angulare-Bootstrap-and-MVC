using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Class
{
    /// <summary>
    /// Vehicle class will store the main details of each vehicle owned.
    /// This will be the database that will be a refrance for the following tables:
    /// Vehicle Repairs
    /// Accidents
    /// Operatives
    /// </summary>
    public class Vehicle
    {
        public Vehicle()
        {
           Sold = false;
          
           SecondHand = false;

            ExpectedYearsOfService = 10;
         
        }

        public virtual Guid Id { get; set; }
         public virtual string LicensePlate { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual string Year { get; set; }
        public virtual float Milage { get; set; }
        public virtual float MaxHeight { get; set; }
        public virtual float MaxWidth { get; set; }
        public virtual string MeasurmentUnit { get; set; }
        public virtual float PurchasePrice { get; set; }
        public virtual DateTime DateOfPurchase { get; set; }
        public virtual float DepreciationPercentage { get; set; }
        public virtual float CurrentValue { get; set; }
        public virtual DateTime? PreviouseMOTDate { get; set; }
        public virtual DateTime NextMOTDate { get; set; }
        public virtual string DocumentLocation { get; set; }
        public virtual DateTime TaxPaidDate { get; set; }
        public virtual DateTime TaxDueDate { get; set; }
        //if the company has bought the vehicle second hand.
        public virtual bool SecondHand { get; set; }
        //if the vehicle is sold the below properties will be populated.
        public virtual bool Sold { get; set; }
        public virtual float? SellingPrice { get; set; }
        public virtual DateTime? DateOfSale { get; set; }
        public virtual int ExpectedYearsOfService { get; set; }
        public virtual int? ActualYearsOfService { get; set; }
        //Many to One relationship
        // one operative is linked to many vehicles.
        public virtual User Operatives { get; set; }

        //to start other tables will not exisit for now.

        //one vehicle is linked to many stock items.
        public virtual ICollection<Stock> Stocks { get; set; }
        // one vehicle can have many repairs.
        public virtual ICollection<MOTRepair> MOTRepairs { get; set; }
        //Many to many
        public virtual ICollection<VehicleInsurance> Insurances { get; set; }
    }
}
