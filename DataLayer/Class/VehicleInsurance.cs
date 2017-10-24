using System;
using System.Collections.Generic;

namespace DataLayer.Class
{
   public  class VehicleInsurance
    {
        public VehicleInsurance()
        {
            Accidents = new List<VehicleAccident>();
        }
        public virtual string Name { get; set; }
        public virtual string InsurancePolicynumber { get; set; }
        public virtual int OfficePhone { get; set; }
        public virtual DateTime Creation { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual Guid Id { get; set; }
        public virtual string LevelOfCover { get; set; }

        public virtual ICollection<VehicleAccident> Accidents { get; set; }
        //many insurance polcies for one vehicle.
        public virtual Vehicle Vehicles { get; set; }

    }
}