using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Receiver : User
    {
        private int receiverId;
        private List<Donation> receivedItems;

        public int receiverId
        {
            get { return receiverId; } set { receiverId = value; }
        }

        public List<Donation> receivedItems
        {
            get { return receivedItems; }
            private set { receivedItems = value; }
        }

        public Receiver(int id, string username, string email, string password, string displayName, string location)
            : base(id, username, email, password, displayName, location)
        {
            this.receiverId = id;
            this.receivedItems = new List<Donation>();
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
