using FinanceServices.Enum;
using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.Serialization;

namespace FinanceServices.Components
{
    [DataContract]
    public class DatabaseProvider
    {
        #region Var
        private Finance_dbDataSet finance_dbDataSet;
        private DatabaseConnectionStatus databaseConnectionStatus;
        private DatabaseStatus databaseStatus;
        #endregion

        #region Propertyes

        public DatabaseConnectionStatus GetDatabaseConnectionStatus
        {
            get
            {
                return databaseConnectionStatus;
            }
        }

        public DatabaseStatus GetDatabaseStatus
        {
            get
            {
                return databaseStatus;
            }
        }

        public Finance_dbDataSet GetDataSet
        {
            get
            {
                return finance_dbDataSet;
            }
        }

        [DataMember]
        public DataTable GetCategoriesDataTable
        {
            get
            {
                return finance_dbDataSet.Categories;
            }
        }
        #endregion

        #region Ctor
        public DatabaseProvider()
        {
            finance_dbDataSet = new Finance_dbDataSet();
        }
        #endregion

        #region Method
        public bool Exsist(string TableName, params string[] values)
        {
            //foreach (var item in dataTable.Rows)
            //{
            //    return true;
            //}

            return false;
        }

        public DataTable GetDatabaseTable(string tableName)
        {
            //finance_dbDataSet.Tables[tableName];

            return finance_dbDataSet.Tables[tableName];
        }

        //public DatabaseResponce GetUser(string login, string password)
        //{
        //    if (login is null || password is null)
        //    {
        //        return new DatabaseResponce()
        //        {
        //            Exception = new DatabaseException() { Title = "Ошибка считывания данных", 
        //                Description = "Проверьте правильность вводимых данных" },
        //            Values = null,
        //            ValueType = typeof(Exception)
        //        };
        //    }

        //    if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        //    {
        //        return new DatabaseResponce()
        //        {
        //            Exception = new DatabaseException()
        //            {
        //                Title = "Ошибка считывания данных",
        //                Description = "Проверьте правильность вводимых данных"
        //            },
        //            Values = null,
        //            ValueType = typeof(Exception)
        //        };
        //    }

        //    finance_dbDataSet.Users.row
        //}
        #endregion
    }
}
