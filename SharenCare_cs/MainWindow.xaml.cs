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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace SharenCare_cs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NpgsqlConnection? connection;
        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            // Set halaman pertama saat MainWindow dimuat
            this.Content = new HomePage(this);
        }

        private void InitializeDatabaseConnection()
        {
            // Replace with your actual connection string
            string connectionString = "Host=flora.db.elephantsql.com;Port=5432;Database=xyasvyry;Username=xyasvyry;Password=J_P0fQMJWx97Mv4tN9l3MGhfkXDgd8ou";

            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("Database connection established.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }
    }
}
