using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    class AccidentWitnessMap : ClassMap<AccidentWitness>
    {
        public AccidentWitnessMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.FirstName);
            Map(x => x.MiddleName);
            Map(x => x.LastName);
            Map(x => x.MobilePhone);
            Map(x => x.OtherPhone);
            Map(x => x.email);
            Map(x => x.Statment);

            References<VehicleAccident>(x => x.Accident);
        }
    }
}
