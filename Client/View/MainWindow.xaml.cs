using Client.View.Pages;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Client
{
    public partial class MainWindow
    {
        #region Var
        #endregion

        #region Ctor
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            Navigator.SetContentFrame(ref MainContentFrame);

            Navigator.Navigate(new Login());
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
    }
}
