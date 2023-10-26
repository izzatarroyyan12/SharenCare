using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Receiver : User
    {
        private int receiverId_;
        private List<Donation> receivedItems_;

        public int ReceiverId
        {
            get { return receiverId_; }
            set { receiverId_ = value; }
        }

        public List<Donation> ReceivedItems
        {
            get { return receivedItems_; }
            private set { receivedItems_ = value; }
        }

        public Receiver(int id, string username, string email, string password, string displayName, string location)
            : base(id, username, email, password, displayName, location)
        {
            this.ReceiverId = id;
            this.ReceivedItems = new List<Donation>();
        }

        public void TakeItem(Donation item)
        {
            // Implementasi logika pengambilan item
        }

        public void SearchItem(Donation item)
        {
            // Implementasi logika pencarian item
        }
    }
}
