using Client.Components;
using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows;

namespace Client.ViewModels
{
    internal class RestoreViewModel : ViewModelBase
    {
        #region Var
        private int secret_code;
        #endregion

        #region Propertyes
        public string Input_code { get; set; }

        public string User_login { get; set; }

        public string User_password { get; set; }
        #endregion

        #region Ctor
        public RestoreViewModel()
        {
            
        }
        #endregion

        #region Methods
        private bool IsCorrect()
        {
            if (int.TryParse(Input_code, out secret_code))
            {
                MessageBox.Show("Проверьте правильно ли вы указали код", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            return true;
        }
        #endregion

        #region Commands
        public ICommand ButtonRestoreCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (IsCorrect())
                    {
                        var obj = Core.GetServiceInstance().Service.Get("Users");

                        for (int i = 0; i < obj.Table.Rows.Count - 1; i++) 
                        { 
                            if (Input_code == obj.Table.Rows[i][6].ToString())
                            {
                                User_login = (string)obj.Table.Rows[i][1];
                                User_password = (string)obj.Table.Rows[i][2];
                                break;
                            }
                        }

                        RaisePropertyChanged(nameof(User_login));

                        RaisePropertyChanged(nameof(User_password));
                    }
                });
            }
        }

        public ICommand ButtonCancelCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Core.GetNavigatorInstance().MainContentViewModel = new LoginViewModel();
                });
            }
        }
        #endregion
    }
}
