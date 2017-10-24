using System;

namespace DataLayer.Class
{
    public class WorkTime
    {
        public WorkTime()
        {
            JobPeriodStarted = DateTime.Now;
            JobPeriodEnded = null;
            ReasonForPeriodEnd = "";
        }

        public virtual Guid Id { get; set; }        
        public virtual DateTime JobPeriodStarted { get; set; }
        public virtual DateTime? JobPeriodEnded { get; set; }
        public virtual string ReasonForPeriodEnd { get; set; }

        // many work times are linked to one work order.
        public virtual WorkOrder Works { get; set; }

        public virtual User Operative { get; set; }
    }
}