using DataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
   public class WageMap : ClassMap<Wage>
    {
        public WageMap()
        {
            Id(x => x.Id);
            Map(x => x.Code);
            Map(x => x.Daily);
            Map(x => x.DailyRate);
            Map(x => x.Hourly);
            Map(x => x.HourlyRate);
            Map(x => x.OverTimeRate);
            Map(x => x.Salery);
            Map(x => x.YearlyRate);

            HasMany<User>(x => x. Employees).Cascade.SaveUpdate();


        }


    }
}
