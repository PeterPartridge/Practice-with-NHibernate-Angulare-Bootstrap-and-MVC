using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{
    public class Material
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string UnitOfMeasurment { get; set; }



        //many materials can have one stock item.
        public virtual ICollection<Stock> Stocks { get; set; }

        public virtual ICollection<MaterialUsed> MaterialsUsed { get; set; }
        
        public virtual ICollection<Pricing> Prices { get; set; }
    }
}
