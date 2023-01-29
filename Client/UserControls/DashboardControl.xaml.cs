using System.Windows;

namespace Client.UserControls
{
    public partial class DashboardControl
    {
        public DashboardControl()
        {
            InitializeComponent();
        }

        private void BtnChangeAccount_Click(object sender, RoutedEventArgs e)
        {
            //Core.GetNavigatorInstance().Navigate("Login");
        }

        private void BtnShutdown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            //Core.GetNavigatorInstance().Navigate(ContentFrame, (sender as ContentControl).Tag.ToString());
        }
    }
}
