using DataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    class VehicleInsuranceMap : ClassMap<VehicleInsurance>
    {
        public VehicleInsuranceMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.InsurancePolicynumber);
            Map(x => x.OfficePhone);
            Map(x => x.Creation);
            Map(x => x.EndDate);
            Map(x => x.LevelOfCover);

            References<Vehicle>(x => x.Vehicles);

            HasMany<VehicleAccident>(x => x.Accidents);
        }
    }
}
