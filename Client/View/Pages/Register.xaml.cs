using Client.Components;
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
            Core.GetInstance().GetNavigator.Navigate("Login");
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length < 4)
            {
                return;
            }

            if (PasswordBox.Password != PasswordRepeatBox.Password)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(FNameBox.Text) || string.IsNullOrWhiteSpace(MNameBox.Text) || string.IsNullOrWhiteSpace(LNameBox.Text))
            {
                return;
            }

            //Core.ServiceManager.AppendUser(new Data.Models.User()
            //{
            //    Login = LoginBox.Text,
            //    Password = PasswordBox.Text,
            //    FirstName = FNameBox.Text,
            //    LastName = LNameBox.Text
            //});

            Core.GetInstance().GetNavigator.NavigateNew(new ClientPage()
            {
                Content = new SecretCode(LoginBox.Text.GetHashCode() + FNameBox.Text.GetHashCode(), 1),
                Title = "SecretCode"
            });
        }
    }
}
