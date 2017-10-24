using DataLayer.Class;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    class MOTRepairMap : ClassMap<MOTRepair>
    {
        public MOTRepairMap()
        {

            Id(x => x.Id);
            Map(x => x.RepairStartedDate);
            Map(x => x.EstimatedRepairEndDate);
            Map(x => x.ActualRepairEndDate);
            Map(x => x.EstimatedCost);
            Map(x => x.ActualCost);
            Map(x => x.WhatWillBeRepaired);
            


            References<Vehicle>(x => x.Vehicles);
        }
    }
}
