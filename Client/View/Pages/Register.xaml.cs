using System.Windows;
using System.Windows.Controls;

namespace Client.View.Pages
{
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Navigator.GoBack();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            //Core.ServiceManager.AppendUser(new Data.Models.User()
            //{
            //    Login = LoginBox.Text,
            //    Password = PasswordBox.Text,
            //    FirstName = FNameBox.Text,
            //    LastName = LNameBox.Text
            //});
        }
    }
}
