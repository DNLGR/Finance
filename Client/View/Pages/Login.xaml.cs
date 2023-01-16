using Data.Models;
using System.Windows;
using System.Windows.Controls;

namespace Client.View.Pages
{
    public partial class Login : Page, DatabaseHostService.IDatabaseServiceCallback
    {
        ServiceManager serviceManager;
        public Login()
        {
            InitializeComponent();

            DataContext = this;

            serviceManager = new ServiceManager();
        }

        public void DataCallBack(string obj)
        {
            
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Core.LocalUser = serviceManager.DatabaseServiceClient.ExsistUser(LoginBox.Text, PasswordBox.Password);

            if (Core.LocalUser != null)
            {
                Navigator.Navigate(new Content());
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(new Register());
        }
    }
}
