using DataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    class WorkTimeMap : ClassMap<WorkTime>
    {
        public WorkTimeMap()
        {
            Id(x => x.Id);
            Map(c => c.JobPeriodStarted);
            Map(c => c.JobPeriodEnded);
            Map(c => c.ReasonForPeriodEnd);

            References<WorkOrder>(x => x.Works);
            References<User>(c => c.Operative);
        }
    }
}
