using DataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
     public class VehicleMap : ClassMap<Vehicle>
     {
         public VehicleMap()
         {
             Id(x => x.Id);
             Map(x => x.LicensePlate);
             Map(x => x.Make);
             Map(x => x.Model);
             Map(x => x.Milage);
             Map(x => x.Year);
             Map(x => x.MaxHeight);
             Map(x => x.MaxWidth);
             Map(x => x.NextMOTDate);
             Map(x => x.PreviouseMOTDate);
             Map(x => x.DateOfPurchase);
             Map(x => x.PurchasePrice);
             Map(x => x.DepreciationPercentage);
             Map(x => x.CurrentValue);
             Map(x => x.DocumentLocation);
             Map(x => x.TaxPaidDate);
             Map(x => x.TaxDueDate);
             Map(x => x.SecondHand);
             Map(x => x.Sold);
             Map(x => x.SellingPrice);
             Map(x => x.DateOfSale);
            Map(x => x.ExpectedYearsOfService);
            Map(x => x.ActualYearsOfService);
            Map(x => x.MeasurmentUnit);


            References<User>(x => x.Operatives);

         }

     }
}
