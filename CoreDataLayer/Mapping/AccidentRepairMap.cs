using CoreDataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    class AccidentRepairMap : ClassMap<AccidentRepair>
    {
        public AccidentRepairMap()
        {
            Id(x => x.Id);
            Map(x => x.RepairStartedDate);
            Map(x => x.EstimatedRepairEndDate);
            Map(x => x.EstimatedCost);
            Map(x => x.ActualCost);
            Map(x => x.ActualRepairEndDate);
            Map(x => x.WhatWillBeRepaired);
            Map(x => x.WillVehicleBeRepaired);
     

            References<VehicleAccident>(x => x.Accident);
        }
    }
}
