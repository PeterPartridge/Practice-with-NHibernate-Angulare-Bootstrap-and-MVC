using DataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class VehicleAccidentMap : ClassMap<VehicleAccident>
    {
        public VehicleAccidentMap()
        {

            Id(x => x.Id);
            Map(x => x.Accident);
            Map(x => x.DateOfClaim);
            Map(x => x.DisputingClaim);
            Map(x => x.VehicleWrittenOff);
            Map(x => x.PersonLiable);
            Map(x => x.Personalnjury);
            Map(x => x.InsuranceSettelmentPaidOut);
            Map(x => x.TypeOfAccident);

            References<Vehicle>(x => x.Vehicles);

            HasMany<AccidentWitness>(x => x.Witnesses).Table("Witnesses").Cascade.SaveUpdate();
            HasMany<AccidentWitness>(x => x.OtherParties).Table("OtherParties").Cascade.SaveUpdate();
            HasMany<AccidentWitness>(x => x.AccidentRepairs).Table("AccidentRepairs").Cascade.SaveUpdate();

        }
    }
}
