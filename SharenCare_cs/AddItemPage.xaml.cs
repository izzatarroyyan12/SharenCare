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
    public partial class AddItemPage : Page
    {
        private readonly Item item;
        private readonly User user;
        private readonly MainWindow mainWindow;
        private readonly string enteredUsername; // Field to store the enteredUsername
        private string userID;

        public AddItemPage(MainWindow mainWindow, string enteredUsername)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.item = new Item(mainWindow.connection);
            this.user = new User(mainWindow.connection);
            this.enteredUsername = enteredUsername;
            this.userID = user.GetUserID(enteredUsername);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string itemName = nameTB.Text;
            string itemCategory = categoryTB.Text;
            DateTime expireDate = DateTime.Parse(expireTB.Text);
            int quantity = int.Parse(kuantitasTB.Text);
            string note = noteTB.Text;

            bool isDonated = item.Donate(itemName, itemCategory, expireDate, quantity, userID, note);

            if (isDonated)
            {
                MessageBox.Show("Item donated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to donate item.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.mainWindow.Content = new ListItemPage(this.mainWindow);
        }
    }
}
