using DevExpress.Mvvm;
using System;

namespace Client.Components
{
    public class NavigationStore
    {
        #region Var
        private ViewModelBase _databaseContentViewModel;
        private ViewModelBase _mainContentViewModel;
        #endregion

        #region Events
        public event Action DatabaseContentChanged;
        public event Action MainContentChanged;
        #endregion

        #region Propertyes
        public ViewModelBase MainContentViewModel
        {
            get => _mainContentViewModel;
            set
            {
                _mainContentViewModel = value;

                OnMainContentChanged();
            }
        }


        public ViewModelBase DatabaseContentViewModel
        {
            get => _databaseContentViewModel;
            set
            {
                _databaseContentViewModel = value;

                OnDatabaseContentChanged();
            }
        }
        #endregion

        #region Methods
        private void OnMainContentChanged()
        {
            MainContentChanged?.Invoke();
        }

        private void OnDatabaseContentChanged()
        {
            DatabaseContentChanged?.Invoke();
        }
        #endregion
    }
}
