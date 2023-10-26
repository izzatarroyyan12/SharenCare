using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;

namespace SharenCare_cs
{
    public partial class App : Application
    {
        public App()
        {
            // This code will execute when the WPF application starts.
            if (TestConnection())
            {
                MessageBox.Show("Database connected successfully.", "Connection Status", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to connect to the database.", "Connection Status", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool TestConnection()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    return con.State == ConnectionState.Open;
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }

        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection("Server=rosie.db.elephantsql.com;Port=5432;User Id=ydynmhrb;Password=3Sp6XXUEcvS5We2Z14ozwdSWLp5Hdpqz;Database=ydynmhrb;");
        }
    }
}
