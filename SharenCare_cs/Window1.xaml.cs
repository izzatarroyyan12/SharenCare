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

namespace SharenCare_cs
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            // Menambahkan handler acara untuk label "Register here!" jika label ada dalam file XAML
            if (RegisterLabel != null)
            {
                RegisterLabel.MouseLeftButtonDown += RegisterLabel_Click;
            }
        }

        private void RegisterLabel_Click(object sender, MouseButtonEventArgs e)
        {
            // Membuka jendela baru "Window2"
            Window2 window2 = new Window2();
            window2.Show();
            this.Close(); // Menutup jendela saat berpindah ke Window2
        }
    }
}

