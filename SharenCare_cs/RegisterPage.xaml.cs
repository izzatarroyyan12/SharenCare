using System.Windows;
using System.Windows.Controls;

namespace SharenCare_cs
{
    public partial class RegisterPage : Page
    {
        private readonly User user;
        private readonly MainWindow mainWindow;

        public RegisterPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.user = new User(mainWindow.connection);
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTB.Text;
            string displayName = displayNameTB.Text;
            string email = emailTB.Text;
            string location = locationTB.Text;
            string password = passwordTB.Text;

            bool isRegistered = user.Register(username, displayName, email, location, password);

            if (isRegistered)
            {
                MessageBox.Show("User registered successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to register user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Content = new LoginPage(this.mainWindow);
        }
    }
}