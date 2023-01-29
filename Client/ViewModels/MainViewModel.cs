using Client.Components;
using DevExpress.Mvvm;

namespace Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Var
        private readonly NavigationStore _navigationStore;
        #endregion

        #region Propertyes
        public ViewModelBase ContentViewModel { get => _navigationStore.MainContentViewModel; }
        #endregion

        #region Ctor
        public MainViewModel()
        {
            _navigationStore = Core.GetNavigatorInstance();

            _navigationStore.MainContentChanged += OnMainContentChanged;

            _navigationStore.MainContentViewModel = new LoginViewModel();
        }
        #endregion

        #region Methods
        private void OnMainContentChanged()
        {
            RaisePropertyChanged(nameof(ContentViewModel));
        }
        #endregion
    }
}
