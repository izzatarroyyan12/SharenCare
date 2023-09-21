using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    public class User
    {
        private int id;
        private string username;
        private string email;
        private string password;
        private string displayName;
        private string location;
        private bool loggedIn;

        public int id
        {
            get { return id; } set { id = value; }
        }

        public string username
        {
            get { return username; } set { username = value; }
        }

        public string email
        {
            get { return email; } set { email = value; }
        }

        public string password
        {
            get { return password; }
            set { password = value; }
        }

        public string displayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public string location
        {
            get { return location; }
            set { location = value; }
        }

        public bool loggedIn
        {
            get { return loggedIn; }
            private set { loggedIn = value; }
        }

        public User(int id, string username, string email, string password, string displayName, string location)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.password = password;
            this.displayName = displayName;
            this.location = location;
            this.loggedIn = false;
        }

        public User Register(string username, string email, string password)
        {
            // Implementasi logika registrasi
        }

        public bool Login(string username, string password)
        {
            // Implementasi logika login
        }

        public void Logout()
        {
            // Implementasi logika logout
            LoggedIn = false;
        }
    }
}

