using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Admin
    {
        private int id;
        private string username;
        private string email;
        private string password;

        public int id
        {
            get { return id; }
            set { id = value; }
        }

        public string username
        {
            get { return username; }
            set { username = value; }
        }

        public string email
        {
            get { return email; }
            set { email = value; }
        }

        public string password
        {
            get { return password; }
            set { password = value; }
        }

        public Admin(int id, string username, string email, string password)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.password = password;
        }

        public bool Login(string username, string password)
        {
            // Implementasi logika login admin
        }

        public void ManageUsers()
        {
            // Implementasi logika manajemen pengguna (users)
        }

        public void ManageItems()
        {
            // Implementasi logika manajemen item
        }

        public void ManageDonations()
        {
            // Implementasi logika manajemen donasi
        }
    }
}
