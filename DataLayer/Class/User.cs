using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Class
{
    /// <summary>
    /// This is the main class for all workman and is used as a refrance for following tables:
    /// Vehicles
    /// Payroll
    /// Job's
    /// </summary>

    public class User
    {
        public User()
        {
            MiddleName = "";
            email = "";
            TaxCode = "";
            PreferredName = "";
            Vehicles = new List<Vehicle>();
            Trades = new List<Trade>();
            Works = new List<WorkOrder>();


        }

        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PreferredName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual DateTime EmploymentDate { get; set; }
        public virtual DateTime? LeavingDate { get; set; }
        public virtual string Sex { get; set; }
        public virtual Int64 MobilePhone { get; set; }
        public virtual Int64? OfficePhone { get; set; }
        public virtual string email { get; set; }
        public virtual string TaxCode { get; set; }
       
        // Many Operatives to one Company
        public virtual Company Companies { get; set; }

        //one operative can have many vehicles.
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        //Many to One
        public virtual Wage Wages { get; set; }
        // other items removed while we begin to build database.

        
        // Many to Many
        public virtual ICollection<Trade> Trades { get; set; }

        public virtual ICollection<WorkOrder> Works { get; set; }

        /*
       
     

        public ICollection<VehicleAccident> Accidents { get; set; }

        public ICollection<WorkTime> Times { get; set; }*/


    }
}
