using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Donation
    {
        //Attributes
        public int donationID { get; set; }
        public Donor donor { get; set; }
        public Receiver receiver { get; set; }
        public DateTime transactionDate { get; set; }
        public Item item { get; set; }
        public string location { get; set; }
        public string notes { get; set; }
        //Constructor
        public Donation(int donationID, Donor donor, Receiver receiver, DateTime transactionDate, Item item, string location, string notes)
        {
            this.donationID = donationID;
            this.donor = donor;
            this.receiver = receiver;
            this.transactionDate = transactionDate;
            this.item = item;
            this.location = location;
            this.notes = notes;
        }

        // Method to Add an Item to the Donation
        public void addItem(Item itemToAdd)
        {
            //Method Logic
        }

        // Method to Remove an Item from the Donation
        public void removeItem(Item itemToRemove)
        {
            //Method Logic
        }
    }
}
