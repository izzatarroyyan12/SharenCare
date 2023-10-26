using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    public class User
    {
        private static int nextID = 1;

        private int id_;
        private string username_;
        private string email_;
        private string password_;
        private string displayName_;
        private string location_;
        private bool loggedIn_;

        public int Id
        {
            get { return id_; }
            set { id_ = value; }
        }

        public string Username
        {
            get { return username_; }
            set { username_ = value; }
        }

        public string Email
        {
            get { return email_; }
            set { email_ = value; }
        }

        public string Password
        {
            get { return password_; }
            set { password_ = value; }
        }

        public string DisplayName
        {
            get { return displayName_; }
            set { displayName_ = value; }
        }

        public string Location
        {
            get { return location_; }
            set { location_ = value; }
        }

        public bool LoggedIn
        {
            get { return loggedIn_; }
            private set { loggedIn_ = value; }
        }

        public User(int id, string username, string email, string password, string displayName, string location)
        {
            this.Id = nextID;
            nextID++;
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.DisplayName = displayName;
            this.Location = location;
            this.LoggedIn = false;
        }

        public User Register(string username, string email, string password, string displayName, string location)
        {
            return null;
        }

        public bool Login(string username, string password)
        {
            return true;
        }

        public void Logout()
        {
            // Implementasi logika logout
            LoggedIn = false;
        }
    }
}
