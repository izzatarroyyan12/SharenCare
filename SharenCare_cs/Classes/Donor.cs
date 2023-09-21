using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Donor : User
    {
        private int donorId;
        private List<Donation> donatedItem;

        public int donorId
        {
            get { return donorId; } set { donorId = value; } 
        }

        public List<Donation> donatedItem
        {
            get { return donatedItem; }
            private set { donatedItem = value; }
        }

        public Donor(int id, string username, string email, string password, string displayName, string location)
            : base(id, username, email, password, displayName, location)
        {
            this.donorId = id;
            this.donatedItem = new List<Donation>();
        }

        public void DonateItem(Donation item)
        {
        // Implementasi logika pendonasian item
        }

        public void EditItem(Donation item)
        {
            // Implementasi logika pengeditan item
        }
    }
}