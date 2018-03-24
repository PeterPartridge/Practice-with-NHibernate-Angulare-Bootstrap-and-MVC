using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.UserName).Not.Nullable();
            Map(x => x.Title);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.MiddleName);
            Map(x => x.PreferredName);
            Map(x => x.Sex);
            Map(x => x.MobilePhone);
            Map(x => x.OfficePhone);
            Map(x => x.DateOfBirth);
            Map(x => x.EmploymentDate);
            Map(x => x.LeavingDate);
            Map(x => x.email);
            Map(x => x.TaxCode);
          //  Map(x => x.Password).Not.Nullable();

            References<Company>(x => x.Companies);

            References<Wage>(x => x.Wages).Cascade.SaveUpdate();

            HasManyToMany<Trade>(x => x.Trades).Table("TradeAndOperative").Cascade.SaveUpdate();


            HasMany<Vehicle>(x => x.Vehicles)
                         .Table("Vehicle").Cascade.All(); 

            HasMany<WorkOrder>(x => x.Works).Cascade.All();
                         
        }

    }
}
