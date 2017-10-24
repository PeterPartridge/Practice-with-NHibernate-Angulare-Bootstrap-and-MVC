using DataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    class MaterialMap : ClassMap<Material>
    {
        public MaterialMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.UnitOfMeasurment);

            HasMany<Stock>(x => x.Stocks).Table("Stocks").Cascade.None();
            HasMany<MaterialUsed>(x => x.MaterialsUsed).Table("MaterialsUsed").Cascade.None();
            HasMany<Pricing>(x => x.Prices).Table("Prices").Cascade.None();

        }
    }
}
