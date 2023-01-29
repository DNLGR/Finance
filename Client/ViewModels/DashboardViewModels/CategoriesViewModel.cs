﻿using Client.Components;
using Client.Interfaces;
using Client.View.Dashboard;
using DevExpress.Mvvm;
using FinanceServices.Components.Database;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Client.ViewModels.DashboardViewModels
{
    public class CategoriesViewModel : ViewModelBase, IDatabaseContentControl
    {
        #region Propertyes
        public DatabaseTable DatabaseContent { get; set; }

        public DataRow SelectedRow { get; set; }
        #endregion

        #region Ctor
        public CategoriesViewModel()
        {
            if (DatabaseContent == null)
            {
                DatabaseContent = Core.GetServiceInstance().Service.Get("Categories");

                DatabaseContent.Table.Columns[0].ColumnName = "Код категории";

                DatabaseContent.Table.Columns[1].ColumnName = "Наименование категории";

                RaisePropertyChanged(nameof(DatabaseContent));
            }
        }
        #endregion

        #region Methods
        public void OnNavigate()
        {
            if (DatabaseContent is null)
            {
                DatabaseContent = Core.GetServiceInstance().Service.Get("Categories");

                RaisePropertyChanged(nameof(DatabaseContent));
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
