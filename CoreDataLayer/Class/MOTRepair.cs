﻿using System;

namespace CoreDataLayer.Class
{
    public  class MOTRepair
    {
        public MOTRepair()
        {
            ActualRepairEndDate = null;
            ActualCost = null;
        }


        public virtual Guid Id { get; set; }
        public virtual DateTime RepairStartedDate { get; set; }
        public virtual DateTime EstimatedRepairEndDate { get; set; }
        public virtual DateTime? ActualRepairEndDate { get; set; }
        public virtual float EstimatedCost { get; set; }
        public virtual float? ActualCost { get; set; }
        public virtual string WhatWillBeRepaired { get; set; }

        public virtual  Vehicle Vehicles { get; set; }

    }
}