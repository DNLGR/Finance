using FinanceServices.Database;
using FinanceServices.Enum;
using System.Data;
using System.ServiceModel.Syndication;

namespace FinanceServices.Components
{
    public class DatabaseProvider
    {
        #region Var
        private finance_dbDataSet finance_dbDataSet;
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

        public DataTable GetDataTable(string TableName)
        {
            var obj = finance_dbDataSet.Tables["Categories"];

            return finance_dbDataSet.Tables[TableName];
        }
        #endregion

        #region Ctor
        public DatabaseProvider()
        {
            finance_dbDataSet = new finance_dbDataSet();
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
