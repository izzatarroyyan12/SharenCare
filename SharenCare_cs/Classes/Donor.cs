using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Donor : User
    {
        private int donorId_;
        private List<Donation> donatedItem_;

        public int DonorId
        {
            get { return donorId_; }
            set { donorId_ = value; }
        }

        public List<Donation> DonatedItem
        {
            get { return donatedItem_; }
            private set { donatedItem_ = value; }
        }

        public Donor(int id, string username, string email, string password, string displayName, string location)
            : base(id, username, email, password, displayName, location)
        {
            this.DonorId = id;
            this.DonatedItem = new List<Donation>();
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
