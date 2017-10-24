using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Class
{
  public class CustomerAddress
    {
        public CustomerAddress()
        {
            Creation = DateTime.Now;
            IsAtRisk = false;
            Orders = new List<WorkOrder>();
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
        public virtual bool IsAtRisk { get; set; }

        public virtual ICollection<WorkOrder> Orders { get; set; }
    }
}
