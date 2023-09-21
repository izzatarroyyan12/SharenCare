using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int quantity { get; set; }
        public DateTime expiryDate { get; set; }
        public Donor donor { get; set; }

        // Constructor
        public Item(int id, string name, string category, int quantity, DateTime expiryDate, Donor donor)
        {
            // Use the property names to assign values
            this.id = id;
            this.name = name;
            this.category = category;
            this.quantity = quantity;
            this.expiryDate = expiryDate;
            this.donor = donor;
        }

    }
}
