using DataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            Id(x => x.Id);
            Map(c => c.Name);
            Map(c => c.OfficePhone);
            Map(c => c.Contractor);
            Map(c => c.Supplier);
            Map(c => c.MainCompany);
            Map(c => c.IsActive);
            Map(c => c.MobilePhone);
            
            HasMany<CorprateAdress>(x => x.Adresses).Table("CorprateAdress").Cascade.SaveUpdate();
            HasMany<CorprateInsurance>(x => x.Insurances).Table("CorprateInsurance").Cascade.SaveUpdate();
            HasMany<User>(x => x.Operatives).Table("Operative").Cascade.SaveUpdate();
            HasMany<Pricing>(x => x.Prices).Table("Prices").Cascade.SaveUpdate();
            HasMany<Purchase>(x => x.Pruchases).Table("Purchases").Cascade.None();
        }
    }
}
