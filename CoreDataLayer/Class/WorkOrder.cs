using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreDataLayer.Class
{
    public class WorkOrder
    {
        public WorkOrder()
        {
            IsMultipleProperties = false;
            WorkOnHold = false;
            ReasonForHold = "";
            Cancelled = false;
            ReasonForCancelation = "";
            CustomerRefrance  = 00001;
        }

        public virtual Guid Id { get; set; }

        public virtual Int64 CustomerRefrance { get; set; }

        public virtual string JobDescription { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EstimatedEndDate { get; set; }
        public virtual DateTime? ActualEndDate { get; set; }
        
        public virtual bool IsMultipleProperties { get; set; }

        public virtual bool WorkOnHold { get; set; }

        public virtual string ReasonForHold { get; set; }

        public virtual bool Cancelled { get; set; }

        public virtual string ReasonForCancelation { get; set; }

        public virtual ICollection<User>  Employees { get; set; }

        public virtual ICollection<CustomerAddress> Customers { get; set; }

        public virtual ICollection<MaterialUsed> MaterialsUsed { get; set; }

        public virtual ICollection<WorkTime> Times { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}