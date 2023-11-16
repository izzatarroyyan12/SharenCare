using Npgsql;
using NpgsqlTypes;
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
using System.Data.SqlClient;


namespace SharenCare_cs
{
    /// <summary>
    /// Interaction logic for AddItemPage.xaml
    /// </summary>
    public partial class AddItemPage : Page
    {
        private readonly NpgsqlConnection connection;
        private readonly MainWindow mainWindow;
        private readonly string enteredUsername; // Field to store the enteredUsername
        private string userID;

        private NpgsqlConnection conn;
        private string connectionString = "Host=flora.db.elephantsql.com;Port=5432;Database=xyasvyry;Username=xyasvyry;Password=J_P0fQMJWx97Mv4tN9l3MGhfkXDgd8ou";


        public AddItemPage(MainWindow mainWindow, string enteredUsername)
        {
            InitializeComponent();
            InitializeDatabase();
            this.mainWindow = mainWindow;
            this.connection = mainWindow.connection;
            this.enteredUsername = enteredUsername;
            GetUserID();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenConnection();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT insert_item(@_itemname, @_itemcategory, @_expiredate, @_quantity, @_donor, @_note )", connection))
                {
                    cmd.Parameters.AddWithValue("@_itemname", nameTB.Text);
                    cmd.Parameters.AddWithValue("@_itemcategory", categoryTB.Text);
                    cmd.Parameters.AddWithValue("@_expiredate", NpgsqlDbType.Date, DateTime.Parse(expireTB.Text));
                    cmd.Parameters.AddWithValue("@_quantity", NpgsqlDbType.Integer, int.Parse(kuantitasTB.Text));
                    cmd.Parameters.AddWithValue("@_donor", userID);
                    cmd.Parameters.AddWithValue("@_note", noteTB.Text);

                    int result = (int)cmd.ExecuteScalar();

                    if (result == 1)
                    {
                        ShowMessageBox("Item donated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        ShowMessageBox("Failed to donate item.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error: " + ex.Message, "Failed to Donate item", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                CloseConnection();
            }
            this.mainWindow.Content = new ListItemPage(this.mainWindow);
        }

        private void InitializeDatabase()
        {
            conn = new NpgsqlConnection(connectionString);
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

        private void GetUserID()
        {
            try
            {
                // Assuming conn is your NpgsqlConnection object
                conn.Open();
                System.Diagnostics.Debug.WriteLine("Database Connection Opened");

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Assuming enteredUsername is the variable containing the username
                    string sql = "SELECT userid FROM snc_users WHERE username = @EnteredUsername";
                    cmd.CommandText = sql;

                    // Add a parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@EnteredUsername", NpgsqlDbType.Varchar, enteredUsername);

                    System.Diagnostics.Debug.WriteLine($"SQL Query: {sql}");

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assuming the user ID is stored as a string in the database
                            userID = reader["userid"].ToString();
                            System.Diagnostics.Debug.WriteLine($"UserID found: {userID}");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No matching user found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
                System.Diagnostics.Debug.WriteLine("Database Connection Closed");
            }
        }



    }
}
