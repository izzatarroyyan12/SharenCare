using Npgsql;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

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
            this.authentication = new Authentication(mainWindow.connection, mainWindow);
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

            authentication.ShowLoginResult(isAuthenticated, enteredUsername, enteredPassword);
        }
    }

    public class Authentication
    {
        private readonly NpgsqlConnection connection;
        private readonly MainWindow mainWindow;

        public Authentication(NpgsqlConnection connection, MainWindow mainWindow)
        {
            this.connection = connection;
            this.mainWindow = mainWindow;
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

        public void ShowLoginResult(bool isAuthenticated, string enteredUsername, string enteredPassword)
        {
            if (isAuthenticated)
            {
                MessageBox.Show("Login successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Redirect based on user role
                if (enteredUsername.ToLower() == "admin" && enteredPassword == "admin")
                {
                    // Admin login, redirect to AdminDashPage
                    this.mainWindow.Content = new AdminDashPage(this.mainWindow);
                }
                else
                {
                    this.mainWindow.Content = new CustomerDashPage(this.mainWindow);
                }
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
