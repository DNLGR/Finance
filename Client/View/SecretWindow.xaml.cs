using System.Windows;

namespace Client.View
{
    public partial class SecretWindow : Window
    {
        public SecretWindow(string secret_code)
        {
            InitializeComponent();

            SecretCodeTextBlock.Text = secret_code;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
