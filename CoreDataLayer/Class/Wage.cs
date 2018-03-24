using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Class
{/// <summary>
/// This is the table for wages for all  Employees.
///  
/// </summary>
    public class Wage
    {
        public Wage()
        {
             Employees = new List<User>();
        }

        public virtual Guid Id { get; set; }
        public virtual string Code { get; set; }
        public virtual bool Salery { get; set; }
        public virtual bool Hourly { get; set; }
        public virtual bool Daily {get; set; }
        public virtual float? HourlyRate { get; set; }
        public virtual float? YearlyRate { get; set; }
        public virtual float? DailyRate { get; set; }
        public virtual bool OverTimeRate { get; set; }

        //One to Many
        public virtual ICollection<User>  Employees { get; set; }

    }
}
