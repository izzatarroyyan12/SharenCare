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

        private NpgsqlConnection? connection;
        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }
        private void InitializeDatabaseConnection()
        {
            // Replace with your actual connection string
            string connectionString = "Host=localhost;Port=5432;Database=SharenCare;Username=postgres;Password=postgres";

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

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Membuka jendela baru "Window2"
            Window2 window2 = new Window2();
            window2.Show();
            this.Close(); // Menutup jendela saat berpindah ke Window2
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Membuka jendela baru "Window2"
            Window1 window1 = new Window1();
            window1.Show();
            this.Close(); // Menutup jendela saat berpindah ke Window2
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
