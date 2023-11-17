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
    /// Interaction logic for CustomerDashPage.xaml
    /// </summary>
    public partial class CustomerDashPage : Page
    {
        private readonly MainWindow mainWindow;
        private readonly string enteredUsername; // Field to store the enteredUsername


        public CustomerDashPage(MainWindow mainWindow, string enteredUsername)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.enteredUsername = enteredUsername;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Content = new AddItemPage(this.mainWindow, enteredUsername);
        }

        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Content = new LoginPage(this.mainWindow);
        }
    }
}
