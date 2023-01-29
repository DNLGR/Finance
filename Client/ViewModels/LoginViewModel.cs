using Client.Components;
using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Propertyes
        public string User_login { get; set; }
        #endregion

        #region Ctor
        public LoginViewModel()
        {
            Core.GetServiceInstance();
        }
        #endregion

        #region Methods
        private bool IsValid(PasswordBox obj)
        {
            if (string.IsNullOrWhiteSpace(User_login))
            {
                MessageBox.Show("Заполните поле - Логин", "Неккоректный ввод данных", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.Password))
            {
                MessageBox.Show("Заполните поле - Пароль", "Неккоректный ввод данных", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            return true;
        }
        #endregion

        #region Commands
        public ICommand ButtonLoginCommand
        {
            get
            {
                return new DelegateCommand<PasswordBox>(obj =>
                {
                    if (IsValid(obj))
                    {
                        if (Core.GetServiceInstance().Service.Exsist($"SELECT * FROM [Users] WHERE User_login=\'{User_login}\' AND User_password=\'{obj.Password}\'"))
                        {
                            Core.GetNavigatorInstance().MainContentViewModel = new DashboardViewModel();

                            return;
                        }

                        MessageBox.Show("Пользователь не найден, проверьте правильность ввода данных", "Неккоректный ввод данных", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

        public ICommand ButtonRegisterCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Core.GetNavigatorInstance().MainContentViewModel = new RegisterViewModel();
                });
            }
        }

        public ICommand ButtonRestoreCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Core.GetNavigatorInstance().MainContentViewModel = new RestoreViewModel();
                });
            }
        }

        public ICommand ButtonExitCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    System.Windows.Application.Current.Shutdown();
                });
            }
        }
        #endregion
    }
}
