using Client.Components;
using Client.Interfaces;
using DevExpress.Mvvm;
using FinanceServices.Components.Database;
using System.Windows.Input;

namespace Client.ViewModels.DashboardViewModels
{
    public class CompanyViewModel : ViewModelBase, IDatabaseContentControl
    {
        #region Propertyes
        public DatabaseTable DatabaseContent { get; private set; }
        #endregion

        #region Ctor
        public CompanyViewModel()
        {

        }
        #endregion

        #region Methods
        public void OnNavigate()
        {
            if (DatabaseContent is null)
            {
                DatabaseContent = Core.GetServiceInstance().Service.Get("Company");
            }
        }
        #endregion

        #region Commands
        public ICommand AddCommand => throw new System.NotImplementedException();

        public ICommand EditCommand => throw new System.NotImplementedException();

        public ICommand RemoveCommand => throw new System.NotImplementedException();
        #endregion
    }
}
