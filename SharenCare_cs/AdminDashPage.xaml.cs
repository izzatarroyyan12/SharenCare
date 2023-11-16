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
    /// Interaction logic for AdminDashPage.xaml
    /// </summary>
    public partial class AdminDashPage : Page
    {
        private NpgsqlConnection conn;
        private string connectionString = "Host=localhost;Port=5432;Database=SharenCare;Username=postgres;Password=postgres";

        public AdminDashPage(MainWindow mainWindow)
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            conn = new NpgsqlConnection(connectionString);
        }

        private void LoadUserData()
        {
            try
            {
                conn.Open();
                System.Diagnostics.Debug.WriteLine("Database Connection Opened");

                // SQL query to select all data from the snc_users table
                string sql = "SELECT * FROM snc_users";
                System.Diagnostics.Debug.WriteLine($"SQL Query: {sql}");

                // Create a data adapter
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, conn);

                // Create a DataTable to hold the data
                DataTable dataTable = new DataTable();

                // Fill the DataTable with data from the data adapter
                dataAdapter.Fill(dataTable);

                // Output the row count
                System.Diagnostics.Debug.WriteLine($"Row Count: {dataTable.Rows.Count}");

                // Set the DataTable as the ItemsSource for the DataGrid
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\n{ex.StackTrace}", "Error Loading Data", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conn.Close();
                System.Diagnostics.Debug.WriteLine("Database Connection Closed");
            }
        }

        private void btnShowData_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button Clicked");
            LoadUserData();
        }
    }
}
