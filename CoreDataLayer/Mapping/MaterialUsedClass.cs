using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    public class MaterialUsedClass :ClassMap<MaterialUsed>
    {
        public MaterialUsedClass()
        {
            Id(x => x.Id);
            Map(x => x.Amount);
            Map(x => x.WhenItemUsed);
        

            References<Material>(x => x.Materials);

            References<Vehicle>(x => x.Vehicles);

            References<WorkOrder>(x => x.Orders);
        }
    }
}
