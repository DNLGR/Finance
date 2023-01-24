using Client.Components;
using Client.View.Pages;
using System.Windows;

namespace Client
{
    public partial class MainWindow
    {
        #region Ctor
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            Core.GetInstance().GetNavigator.SetContentFrame(ref MainContentFrame);
        }
        #endregion

        #region Methods
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Core.GetInstance().GetNavigator.Navigate("Login");
        }
    }
}
