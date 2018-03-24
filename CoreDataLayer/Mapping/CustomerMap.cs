using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    class CustomerMap : ClassMap<CustomerAddress>
    {
        public CustomerMap()
        {
            Id(x => x.Id);
            Map(x => x.Number);
            Map(x => x.Street);
            Map(x => x.Town);
            Map(x => x.City);
            Map(x => x.Country);
            Map(x => x.PostCode);
            Map(x => x.IsAtRisk);
            References<WorkOrder>(x => x.Orders);
        }
    }
}
