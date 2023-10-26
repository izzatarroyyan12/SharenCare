using SharenCare_cs.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SharenCare_cs
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private int nextUserID = 1;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTB.Text;
            string email = emailTB.Text;
            string password = passwordTB.Text;
            string displayName = displayNameTB.Text;
            string location = locationTB.Text;

            // validasi input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            User newUser = new User(nextUserID, username, email, password, displayName, location);
            nextUserID++;

            // tes nampilin hasil input
            string userDetails = $"User ID: {newUser.Id}\nUsername: {newUser.Username}\nEmail: {newUser.Email}\nDisplayName: {newUser.DisplayName}\nLocation: {newUser.Location}";
            MessageBox.Show("User Details:\n" + userDetails, "User Registration Successful");


        }
        //LoginLabel
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Membuka jendela baru "Window1"
            Window1 window1 = new Window1();
            window1.Show();
            this.Close(); // Menutup jendela saat berpindah ke Window1
        }
    }
}
