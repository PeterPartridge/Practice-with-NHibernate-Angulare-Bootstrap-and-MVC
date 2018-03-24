using System;
using System.Collections.Generic;

namespace CoreDataLayer.Class
{
    public class Purchase
    {
        public virtual Guid Id { get; set; }
        public virtual float ActualPricePaid { get; set; }
        public virtual float AmountPurchased { get; set; }
        public virtual DateTime DatePricePaid { get; set; }
        // many purchases can be linked to one company.
        public virtual Company Companies { get; set; }

        public virtual ICollection<WorkOrder> Orders { get; set; }

        public virtual Stock Stocks { get; set; }
        public virtual User Users { get; set; }
    }
}