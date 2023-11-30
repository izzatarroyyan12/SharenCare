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
            string enteredPassword = passwordTextBox.Text;

            bool isAuthenticated = user.Login(enteredUsername, enteredPassword);

            ShowLoginResult(isAuthenticated, enteredUsername, enteredPassword);
        }

        private void ShowLoginResult(bool isAuthenticated, string enteredUsername, string enteredPassword)
        {
            if (isAuthenticated)
            {
                MessageBox.Show("Login successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Redirect based on user role
                if (enteredUsername.ToLower() == "admin" && enteredPassword == "admin")
                {
                    // Admin login, redirect to AdminDashPage
                    this.mainWindow.Content = new AdminDashPage(this.mainWindow);
                }
                else
                {
                    this.mainWindow.Content = new CustomerDashPage(this.mainWindow, enteredUsername);
                }
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}