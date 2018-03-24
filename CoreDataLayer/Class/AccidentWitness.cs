using System;

namespace CoreDataLayer.Class
{
    public class AccidentWitness
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int MobilePhone { get; set; }
        public virtual int? OtherPhone { get; set; }
        public virtual string email { get; set; }
        public virtual string Statment { get; set; }

        //many witnesses can be part of one accident claim.
        public virtual VehicleAccident Accident { get; set; }
    }
}