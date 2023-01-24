using Client.Components;
using System.Windows;
using System.Windows.Controls;

namespace Client.View.Pages
{
    public partial class Content : Page
    {
        public Content()
        {
            InitializeComponent();
        }

        private void BtnChangeAccount_Click(object sender, RoutedEventArgs e)
        {
            Core.GetInstance().GetNavigator.Navigate("Login");
        }

        private void BtnShutdown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            Core.GetInstance().GetNavigator.Navigate(ContentFrame, (sender as ContentControl).Tag.ToString());
        }
    }
}
