using Npgsql;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SharenCare_cs
{
    public partial class LoginPage : Page
    {
        private readonly Authentication authentication;
        private readonly MainWindow mainWindow;

        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.authentication = new Authentication(mainWindow.connection);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Ganti konten dengan halaman lain (misalnya, RegisterPage)
            this.mainWindow.Content = new RegisterPage(this.mainWindow);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            // Perform the login check using encapsulated logic
            bool isAuthenticated = authentication.CheckLogin(enteredUsername, enteredPassword);

            ShowLoginResult(isAuthenticated);
        }

        private void ShowLoginResult(bool isAuthenticated)
        {
            if (isAuthenticated)
            {
                MessageBox.Show("Login successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private class Authentication
        {
            private readonly NpgsqlConnection connection;

            public Authentication(NpgsqlConnection connection)
            {
                this.connection = connection;
            }

            public bool CheckLogin(string username, string password)
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
                finally
                {
                    CloseConnection();
                }
            }

            private void CloseConnection()
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
