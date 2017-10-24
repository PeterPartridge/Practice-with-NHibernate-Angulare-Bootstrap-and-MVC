using DataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    class CorprateInsuranceMap : ClassMap<CorprateInsurance>
    {
        public CorprateInsuranceMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.InsurancePolicynumber);
            Map(x => x.OfficePhone);
            Map(x => x.Creation);
            Map(x => x.EndDate);
            References<Company>(x => x.Company);

        }
    }
}
