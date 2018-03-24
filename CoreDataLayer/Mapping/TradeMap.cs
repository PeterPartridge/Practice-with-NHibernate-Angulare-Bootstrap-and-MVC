using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
   public class TradeMap : ClassMap<Trade>
    {
        public TradeMap()
        {
            Id(x => x.Id);
            Map(x => x.Description);
            Map(x => x.Code);
            Map(x => x.Name);

            HasManyToMany<User>(x => x. Employees).Table("TradeAndOperative") ;
        }
    }
}
