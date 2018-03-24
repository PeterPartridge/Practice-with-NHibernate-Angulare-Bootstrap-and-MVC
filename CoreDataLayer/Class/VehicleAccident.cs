using System;
using System.Collections.Generic;

namespace CoreDataLayer.Class
{
    public class VehicleAccident
    {
        public VehicleAccident()
        {
            VehicleWrittenOff = false;
            Personalnjury = false;
            DateOfClaim = DateTime.Now;
            DisputingClaim = false;
            Witnesses = new List<AccidentWitness>();
            OtherParties = new List<OtherAccidentParty>();
        }

        public virtual Guid Id { get; set; }       
        public virtual bool VehicleWrittenOff { get; set; }
        public virtual bool Personalnjury { get; set; }
        public virtual string TypeOfAccident { get; set; }
        public virtual string LocationOfDamage { get; set; }
        public virtual string PersonLiable { get; set; }
        public virtual bool DisputingClaim { get; set; }
        public virtual float? InsuranceSettelmentPaidOut { get; set; }
        public virtual DateTime DateOfClaim { get; set; }
        public virtual DateTime Accident { get; set; }

        //Many accident claims are for one Vehicle
        public virtual Vehicle Vehicles { get; set; }

        public virtual VehicleInsurance Insurances { get; set; }

        public virtual ICollection<AccidentWitness> Witnesses { get; set; }

        public virtual ICollection<OtherAccidentParty> OtherParties { get; set; }

        public virtual ICollection<AccidentRepair> AccidentRepairs { get; set; }


    }
}