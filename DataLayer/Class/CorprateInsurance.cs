using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Class
{
   public class CorprateInsurance
    {
        public CorprateInsurance()
        {
            Creation = DateTime.Now;
        }


        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string InsurancePolicynumber { get; set; }
        public virtual int OfficePhone { get; set; }
        public virtual DateTime Creation { get; set; }
        public virtual DateTime? EndDate { get; set; }

        public virtual Company Company { get; set; }
    }
}
