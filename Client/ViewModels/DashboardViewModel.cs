using Client.Components;
using Client.Interfaces;
using Client.ViewModels.DashboardViewModels;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        #region Var
        private NavigationStore _navigationStore;

        private ViewModelBase _balanceViewModel;
        private ViewModelBase _categoriesViewModel;
        private ViewModelBase _companyViewModel;
        private ViewModelBase _descriptionViewModel;
        private ViewModelBase _factorsViewModel;
        private ViewModelBase _leadersViewModel;
        private ViewModelBase _propertyesViewModel;
        private ViewModelBase _usersViewModel;

        private List<ViewModelBase> ViewModels;
        #endregion

        #region Propertyes
        public ViewModelBase ComtentDatabaseViewModel { get => _navigationStore.DatabaseContentViewModel; }
        #endregion


        #region Ctor
        public DashboardViewModel() 
        {
            _navigationStore = Core.GetNavigatorInstance();

            _navigationStore.DatabaseContentChanged += OnDatabaseContentChanged;

            InitializeUserConrols();

            _navigationStore.DatabaseContentViewModel = GetViewModel("Balance");
        }

        #endregion

        #region Methods
        private void InitializeUserConrols()
        {
            _balanceViewModel = new BalanceViewModel();
            _categoriesViewModel = new CategoriesViewModel();
            _companyViewModel = new CompanyViewModel();
            _descriptionViewModel = new DescriptionViewModel();
            _factorsViewModel = new FactorsViewModel();
            _leadersViewModel = new LeadersViewModel();
            _propertyesViewModel = new PropertyesViewModel();
            _usersViewModel = new UsersViewModel();

            ViewModels = new List<ViewModelBase>()
            {
                _balanceViewModel,
                _categoriesViewModel,
                _companyViewModel,
                _descriptionViewModel,
                _factorsViewModel,
                _leadersViewModel,
                _propertyesViewModel,
                _usersViewModel
            };
        }

        private ViewModelBase GetViewModel(string name)
        {
            switch (name)
            {
                case "Balance": return Navigate(_balanceViewModel);
                case "Categories": return Navigate(_categoriesViewModel);
                case "Company": return Navigate(_companyViewModel);
                case "Description": return Navigate(_descriptionViewModel);
                case "Factors": return Navigate(_factorsViewModel);
                case "Leaders": return Navigate(_leadersViewModel);
                case "Propertyes": return Navigate(_propertyesViewModel);
                case "Users": return Navigate(_usersViewModel);

                default: return null;   
            }
        }

        private ViewModelBase Navigate(ViewModelBase obj)
        {
            (obj as IDatabaseContentControl).OnNavigate();

            return obj;
        }

        private void OnDatabaseContentChanged()
        {
            RaisePropertyChanged(nameof(ComtentDatabaseViewModel));
        }
        #endregion

        #region Commands
        public ICommand ButtonNavigateCommand
        {
            get
            {
                return new DelegateCommand<string>(obj =>
                {
                    Core.GetNavigatorInstance().DatabaseContentViewModel = GetViewModel(obj);
                });
            }
        }

        public ICommand ButtonUserChangeCommand
        {
            get
            {
                return new DelegateCommand<string>(obj =>
                {
                    Core.GetNavigatorInstance().MainContentViewModel = new LoginViewModel();
                });
            }
        }

        public ICommand ButtonExitCommand
        {
            get
            {
                return new DelegateCommand<string>(obj =>
                {
                    App.Current.Shutdown();
                });
            }
        }
        #endregion
    }
}
