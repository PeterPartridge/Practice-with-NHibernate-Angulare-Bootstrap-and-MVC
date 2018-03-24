using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    class PriceMap : ClassMap<Pricing>
    {
        public PriceMap()
        {
            Id(x => x.Id);
            Map(x => x.AgreedPrice);
            Map(x => x.CurrentPricing);
            Map(x => x.AgreementCreation);
            Map(x => x.AgreementEnd);
            Map(x => x.MaxPrice);

            References<Company>(x => x.Campanies);
            References<Material>(x => x.Materials);

        }
    }
}
