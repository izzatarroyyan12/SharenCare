using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    class Admin
    {
        private int adminId;
        private string adminUsername;
        private string adminEmail;
        private string adminPassword;

        public int Id
        {
            get { return adminId; }
            set { adminId = value; }
        }

        public string Username
        {
            get { return adminUsername; }
            set { adminUsername = value; }
        }

        public string Email
        {
            get { return adminEmail; }
            set { adminEmail = value; }
        }

        public string Password
        {
            get { return adminPassword; }
            set { adminPassword = value; }
        }

        public Admin(int id, string username, string email, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }

        public bool Login(string username, string password)
        {
            return true;
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
