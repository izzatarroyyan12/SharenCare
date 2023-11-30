using System.Windows;
using System.Windows.Controls;

namespace SharenCare_cs
{
    public partial class LoginPage : Page
    {
        private readonly User user;
        private MainWindow mainWindow;

        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.user = new User(mainWindow.connection);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Content = new RegisterPage(this.mainWindow);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordBox.Password;

            User authenticatedUser = user.AuthenticateUser(enteredUsername, enteredPassword);

            if (authenticatedUser != null)
            {
                MessageBox.Show("Login successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Redirect based on user role
                authenticatedUser.RedirectToDashboard(this.mainWindow);
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}