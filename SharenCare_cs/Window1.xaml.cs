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
using System.Windows.Shapes;
using Npgsql;
namespace SharenCare_cs
{
    public partial class Window1 : Window
    {
        private NpgsqlConnection connection;
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Membuka jendela baru "Window2"
            Window2 window2 = new Window2(connection);
            window2.Show();
            this.Close(); // Menutup jendela saat berpindah ke Window2
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

