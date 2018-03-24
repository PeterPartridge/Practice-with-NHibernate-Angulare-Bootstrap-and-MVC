using System;

namespace CoreDataLayer.Class
{
    public class MaterialUsed
    {
        public virtual Guid Id { get; set; }

        public virtual float Amount { get; set; }
        public virtual  DateTime WhenItemUsed { get; set; }
        // many materials used are linked to 1 material item
        public virtual Material Materials { get; set; }
        public virtual Vehicle Vehicles { get; set; }
        //Many materials used for on works order
        public virtual WorkOrder Orders { get; set; }
    }
}