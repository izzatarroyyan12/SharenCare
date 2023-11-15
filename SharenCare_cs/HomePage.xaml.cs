using Npgsql;
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

namespace SharenCare_cs
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    // HomePage.xaml.cs
    public partial class HomePage : Page
    {
        private MainWindow mainWindow;

        public HomePage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Content = new LoginPage(this.mainWindow);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Content = new RegisterPage(this.mainWindow);
        }
    }

}
