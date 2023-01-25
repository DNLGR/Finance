using Client.Components;
using System.Data;
using System.Windows.Controls;

namespace Client.View.Pages.Database
{
    public partial class DBCategories : Page
    {
        public DataTable categoriesDataTable { get; set; }

        public DBCategories()
        {
            InitializeComponent();

            //Core.GetInstance().GetServiceManager.DatabaseServiceClient.GetDatabaseTable("Categories");

            DataContext = this;
        }

        private void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            categoriesDataTable = Core.GetInstance().GetServiceManager.DatabaseServiceClient.Pro
        }
        private void BtnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void BtnRemove_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
