using Client.Components;
using System.Windows;

namespace Client.View.Pages
{
    public partial class Login
    {
        public Login()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //var obj =  Core.GetInstance().DeSerialize<DatabaseAnswer>(Core.GetInstance().GetServiceManager.DatabaseServiceClient.UserExist(
            //    new User()
            //    {
            //        LoginHash = LoginBox.Text,
            //        PasswordHash = PasswordBox.Password
            //    }
            //));

            //if (obj.Exception != null)
            //{
            //    MessageBox.Show(obj.Exception.Description, obj.Exception.Title, MessageBoxButton.OK, MessageBoxImage.Error);

            //    return;
            //}

            //Core.GetInstance().SetUser = (User)obj.Parametr;

            Core.GetInstance().GetNavigator.Navigate("Content");
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Core.GetInstance().GetNavigator.Navigate("Register");
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
