using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Receiver
    {
        private int receiverId;
        private List<Donation> receivedItems;

        public int receiver_Id { get { return receiverId; } }
        public List<Donation> received_Items { get { return receivedItems; } set { receivedItems = value; } }

        public void takeItem()
        {
            //logic
        }
        public void searchItem()
        {
            //logic
        }
    }
}
