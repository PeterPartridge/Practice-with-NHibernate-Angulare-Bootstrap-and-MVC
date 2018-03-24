using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    class WorksOrderMap : ClassMap<WorkOrder>
    {
        public WorksOrderMap()
        {
            Id(x => x.Id);
            Map(x => x.CustomerRefrance);
            Map(x => x.JobDescription);
            Map(x => x.EstimatedEndDate);
            Map(x => x.ActualEndDate);
            Map(x => x.IsMultipleProperties);
            Map(x => x.WorkOnHold);
            Map(x => x.ReasonForHold);
            Map(x => x.Cancelled);
            Map(x => x.ReasonForCancelation);


            HasMany<User>(x => x.Employees).Cascade.SaveUpdate();
            HasMany<CustomerAddress>(x => x.Customers).Table("Customers").Cascade.None();
            HasMany<MaterialUsed>(x => x.MaterialsUsed).Table("MaterialsUsed").Cascade.All();
            HasMany<WorkTime>(x => x.Times).Table("Times").Cascade.All();
            HasMany<Purchase>(x => x.Purchases).Table("Purchases").Cascade.All();
        }
    }
}
