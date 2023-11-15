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
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private readonly NpgsqlConnection connection;
        private readonly MainWindow mainWindow;

        public RegisterPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.connection = mainWindow.connection;
        }
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenConnection();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT insert_user(@_userName, @_displayName, @_email, @_location, @_password)", connection))
                {
                    cmd.Parameters.AddWithValue("@_userName", usernameTB.Text);
                    cmd.Parameters.AddWithValue("@_displayName", displayNameTB.Text);
                    cmd.Parameters.AddWithValue("@_email", emailTB.Text);
                    cmd.Parameters.AddWithValue("@_location", locationTB.Text);
                    cmd.Parameters.AddWithValue("@_password", passwordTB.Text);

                    int result = (int)cmd.ExecuteScalar();

                    if (result == 1)
                    {
                        ShowMessageBox("User registered successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        ShowMessageBox("Failed to register user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error: " + ex.Message, "Failed to Register User", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Content = new LoginPage(this.mainWindow);
        }

        private void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void ShowMessageBox(string message, string title, MessageBoxButton button, MessageBoxImage icon)
        {
            MessageBox.Show(message, title, button, icon);
        }
     
    }
}