using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Class
{
   public class Pricing
    {
        public virtual Guid Id { get; set; }
        public virtual float AgreedPrice { get; set; }
        public virtual float MaxPrice { get; set; }       
        public virtual DateTime AgreementCreation { get; set; }
        public virtual DateTime? AgreementEnd { get; set; }
        public virtual string UnitOfMeasurment { get; set; }

        public virtual bool CurrentPricing { get; set; }

        public virtual Company Campanies { get; set; }
        public virtual Material Materials { get; set; }


    }
}
