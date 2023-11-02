using System;
using System.Collections.Generic;
using System.Data;
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
using Npgsql;
namespace SharenCare_cs
{
    public partial class Window1 : Window
    {
        private readonly NpgsqlConnection connection;

        public Window1(NpgsqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Open a new instance of "Window2"
            Window2 window2 = new Window2(connection);
            window2.Show();
            this.Close(); // Close the current window when switching to Window2
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            // Perform the login check (you need to replace this with your actual logic)
            bool isAuthenticated = CheckLogin(enteredUsername, enteredPassword);

            if (isAuthenticated)
            {
                MessageBox.Show("Login successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CheckLogin(string username, string password)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) FROM snc_users WHERE username = @username AND password = @password", connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0; // If count is greater than 0, the user with the provided username and password exists.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}

