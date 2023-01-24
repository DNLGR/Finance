using Client.Components;
using System.Windows;
using System.Windows.Controls;

namespace Client.View.Pages
{
    public partial class SecretCode : Page
    {
        public int User_secret_code { get; set; }

        public SecretCode()
        {
            InitializeComponent();

            DataContext = this;

            User_secret_code = 0;
        }

        public SecretCode(int hashed_data, int user_id)
        {
            InitializeComponent();

            DataContext = this;

            User_secret_code = 0;

            User_secret_code = hashed_data;

            //Core.GetInstance().GetServiceManager.DatabaseServiceClient.SetUserCode(hashed_data, user_id);
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            Core.GetInstance().GetNavigator.Navigate("Content");
        }
    }
}
