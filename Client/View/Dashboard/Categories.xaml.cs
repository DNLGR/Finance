using System.Windows;

namespace Client.View.Dashboard
{
    public partial class Categories : Window
    {
        public Categories()
        {
            InitializeComponent();
        }

        public Categories(string Title, string ButtonText)
        {
            InitializeComponent();
            HeaderText.Text = Title;
            ButtonControl.Content = ButtonText;
        }

        public Categories(string Title, string ButtonText, string value)
        {
            InitializeComponent();
            HeaderText.Text = Title;
            ButtonControl.Content = ButtonText;
            InputControl.Text = value;
        }
    }
}
