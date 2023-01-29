using Client.Components;
using Client.Interfaces;
using DevExpress.Mvvm;
using FinanceServices.Components.Database;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels.DashboardViewModels
{
    public class CategoriesViewModel : ViewModelBase, IDatabaseContentControl
    {
        #region Propertyes
        public DatabaseTable DatabaseContent { get; private set; }

        #endregion

        #region Ctor
        public CategoriesViewModel()
        {

        }
        #endregion

        #region Methods
        public void OnNavigate()
        {
            if (DatabaseContent is null)
            {
                DatabaseContent = Core.GetServiceInstance().Service.Get("Categories");
            }
        }
        #endregion

        #region Commands
        public ICommand AddCommand
        {
            get
            {
                return new DelegateCommand(() => { 
                    
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new DelegateCommand(() => {

                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new DelegateCommand(() => {

                });
            }
        }
        #endregion
    }
}
