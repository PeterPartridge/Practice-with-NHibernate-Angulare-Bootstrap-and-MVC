using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Class
{
   public class CorprateAdress
    {
        public CorprateAdress()
        {
            Country = "United Kingdom";
            CurrentAddress = true;
            Creation = DateTime.Now;
        }

        public virtual Guid Id { get; set; }
     
        public virtual int Number { get; set; }
        public virtual string Street { get; set; }
        public virtual string Town { get; set; }
        public virtual string City { get; set; }
        public virtual string County { get; set; }
        public virtual string Country { get; set; }
        public virtual string PostCode { get; set; }
        public virtual DateTime Creation { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual bool CurrentAddress { get; set; }

        public virtual Company Companies { get; set; }
    }
}
