using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    class PurchaseMap : ClassMap<Purchase>
    {
        public PurchaseMap()
        {
            Id(x => x.Id);
            Map(x => x.ActualPricePaid);
            Map(x => x.AmountPurchased);
            Map(x => x.DatePricePaid);

            HasMany<WorkOrder>(x => x.Orders).Table("WorksOrder").Cascade.None();
            References<Vehicle>(x => x.Companies);
            References<Material>(x => x.Users);
            References<Material>(x => x.Stocks);

        }
    }
}
