using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Donor
    {
        private int donorId;
        private List<Donation> donatedItem;

        public int donor_Id { get { return donorId; } }
        public List<Donation> donated_Item { get { return donatedItem; } set { donatedItem = value; } }

        public void donateItem()
        {
            //logic
        }
        public void editItem()
        {
            //logic
        }
    }
}
