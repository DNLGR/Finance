using System.Collections.Generic;
using System.Windows.Controls;

namespace Client.View.Pages
{
    public partial class Append : Page
    {
        public Append()
        {
            InitializeComponent();
        }

        public Append(List<Control> controls)
        {
            InitializeComponent();

            AppendControls(ContentPanel, controls);
        }

        private void AppendControls(WrapPanel contentControl, List<Control> controls)
        {
            foreach (var item in controls)
            {
                contentControl.Children.Add(item);
            }
        }
    }
}
