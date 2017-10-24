using System;

namespace DataLayer.Class
{
    public class OtherAccidentParty
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int MobilePhone { get; set; }
        public virtual int? OtherPhone { get; set; }
        public virtual string email { get; set; }
        public virtual string InsuranceCompany { get; set; }
        public virtual string PolicyNumber { get; set; }

        //many other parties can be added to one claim.
        public virtual VehicleAccident Accident { get; set; }
    }
}