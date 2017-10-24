using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Class
{
    public class Company
    {
        public Company()
        {
            Contractor = false;
            Supplier = false;
            Adresses = new List<CorprateAdress>();
            Insurances = new List<CorprateInsurance>();
            Operatrives = new List<User>();

        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Contractor { get; set; }
        public virtual bool Supplier { get; set; }
   
        public virtual Int64 MobilePhone { get; set; }
        public virtual Int64 OfficePhone { get; set; }

        public virtual ICollection<CorprateAdress> Adresses { get; set; }
        public virtual ICollection<CorprateInsurance> Insurances { get; set; }
        public virtual ICollection<User> Operatrives { get; set; }
        public virtual ICollection<Pricing> Prices { get; set; }
        public virtual ICollection<Purchase> Pruchases { get; set; }
        
    }
}
