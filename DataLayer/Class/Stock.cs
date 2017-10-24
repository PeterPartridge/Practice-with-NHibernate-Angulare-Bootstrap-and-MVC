using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Class
{
    
    public class Stock
    {
        public virtual Guid Id { get; set; }
        public virtual double MinStockLevel { get; set; }
        public virtual double MaxStockLevel { get; set; }
        public virtual double CurrentStockLevel { get; set; }

        //one stock items for many prices.
        public virtual ICollection<Pricing> Prices { get; set; }
        //many stock items for one vehicle.
        //one vehicle is linked to many Stock items.
        public virtual Vehicle Vehicles { get; set; }

        //one stock item can have many material's.
        // many stock items are linked to one Material.
        public virtual Material Materials { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
