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
    /// Interaction logic for AddItemPage.xaml
    /// </summary>
    public partial class AddItemPage : Page
    {
        private readonly MainWindow mainWindow;

        public AddItemPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Content = new ListItemPage(this.mainWindow);
        }
    }
}
