using SharenCare_cs.Classes;
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
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private NpgsqlConnection connection;
        public Window2(NpgsqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }


        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check connection
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                //Operations
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT insert_user(@_userName, @_displayName, @_email, @_location, @_password)", connection);
                cmd.Parameters.AddWithValue("@_userName", usernameTB.Text);
                cmd.Parameters.AddWithValue("@_displayName", displayNameTB.Text);
                cmd.Parameters.AddWithValue("@_email", emailTB.Text);
                cmd.Parameters.AddWithValue("@_location", locationTB.Text);
                cmd.Parameters.AddWithValue("@_password", passwordTB.Text);

                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    MessageBox.Show("User registered successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to register user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                //Close connection
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed to Register User", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //LoginLabel
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Membuka jendela baru "Window1"
            Window1 window1 = new Window1(connection);
            window1.Show();
            this.Close(); // Menutup jendela saat berpindah ke Window1
        }
    }
}
