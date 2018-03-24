using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    class StockMap : ClassMap<Stock>
    {
        public StockMap()
        {
            Id(x => x.Id);
            Map(x => x.MaxStockLevel);
            Map(x => x.MinStockLevel);
            Map(x => x.CurrentStockLevel);

            HasMany<Stock>(x => x.Prices).Table("Prices").Cascade.None();
            
            HasMany<Pricing>(x => x.Purchases).Table("Purchases").Cascade.None();

            References<Vehicle>(x => x.Vehicles);

            References<Material>(x => x.Materials);
        }
    }
}
