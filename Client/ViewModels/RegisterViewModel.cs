using Client.Components;
using Client.Models;
using Client.View;
using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        #region Propertyes
        public User Local_user { get; set; }

        public string UserRepeatPassword { get; set; }
        #endregion

        #region Ctor
        public RegisterViewModel()
        {
            Local_user = new User();
        }
        #endregion

        #region Methods
        private bool IsValid()
        {
            if (string.IsNullOrEmpty(Local_user.User_login))
            {
                MessageBox.Show("Заполните логин пользователя", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            if (string.IsNullOrEmpty(Local_user.User_password))
            {
                MessageBox.Show("Заполните пароль пользователя", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            if (string.IsNullOrEmpty(Local_user.User_first_name))
            {
                MessageBox.Show("Заполните фамилию пользователя", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            if (string.IsNullOrEmpty(Local_user.User_middle_name))
            {
                MessageBox.Show("Заполните имя пользователя", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            if (string.IsNullOrEmpty(Local_user.User_last_name))
            {
                MessageBox.Show("Заполните отчество пользователя", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            if (Local_user.User_password.Length < 4 && (Local_user.User_password != UserRepeatPassword))
            {
                MessageBox.Show("Проверьте правильность ввода пароля, пароль должен состоять из 4 и более символов", 
                    "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            return true;
        }
        #endregion

        #region Commands
        public ICommand ButtonRegisterCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (IsValid())
                    {
                        Local_user.User_secret_code = Local_user.User_login.GetHashCode() + Local_user.User_first_name.GetHashCode();

                        new SecretWindow(Local_user.User_secret_code.ToString()).ShowDialog();

                        Core.GetServiceInstance().Service.Execute("INSERT INTO Users ([User_login], [User_password], [User_first_name], " +
                            "[User_middle_name], [User_last_name], [User_secret_code], [User_position_code], [User_role_code]) VALUES" +
                            $"('{Local_user.User_login}', '{Local_user.User_password}', '{Local_user.User_first_name}', " +
                            $"'{Local_user.User_middle_name}', '{Local_user.User_last_name}', {Local_user.User_secret_code}, " +
                            $"3, 2)");

                        Core.GetNavigatorInstance().MainContentViewModel = new DashboardViewModel();
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
