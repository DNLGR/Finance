using Client.Components;
using Client.Interfaces;
using Client.View.Dashboard;
using DevExpress.Mvvm;
using FinanceServices.Components.Database;
using System.Data;
using System.Windows.Forms;
using System.Windows.Input;

namespace Client.ViewModels.DashboardViewModels
{
    public class CompanyViewModel : ViewModelBase, IDatabaseContentControl
    {
        #region Propertyes
        public DatabaseTable DatabaseContent { get; private set; }

        public DataRow SelectedRow { get; set; }
        #endregion

        #region Ctor
        public CompanyViewModel()
        {
            if (DatabaseContent == null)
            {
                DatabaseContent = Core.GetServiceInstance().Service.Get("Company");

                DatabaseContent.Table.Columns[0].ColumnName = "Код записи";

                DatabaseContent.Table.Columns[1].ColumnName = "УНП организации";

                DatabaseContent.Table.Columns[2].ColumnName = "Наименование организации";

                DatabaseContent.Table.Columns[3].ColumnName = "Правовая форма управления";

                DatabaseContent.Table.Columns[4].ColumnName = "Направление компании";

                DatabaseContent.Table.Columns[5].ColumnName = "Адресс компании";

                RaisePropertyChanged(nameof(DatabaseContent));
            }
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
        public ICommand AddCommand
        {
            get
            {
                return new DelegateCommand(() => {
                    new Categories("Добавление категории", "Добавить категорию").ShowDialog();
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new DelegateCommand(() => {
                    new Categories("Рудактирование категории", "Сохранить").ShowDialog();
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new DelegateCommand(() => {
                    if (MessageBox.Show("Вы действительно хотите удалить эту хапись ?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DatabaseContent.Table.Rows.Remove(SelectedRow);

                        RaisePropertyChanged(nameof(DatabaseContent));
                    }
                });
            }
        }
        #endregion
    }
}
