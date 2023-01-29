using System.Data.OleDb;
using System.Data;
using FinanceServices.Interfaces;
using System;
using System.Windows;

namespace FinanceServices.Components
{
    public class DatabaseProvider : IDatabaseProvider
    {
        #region Var
        private string databaseConnectionString;
        private OleDbCommand databaseCommand;
        private OleDbConnection databaseConnection;
        private OleDbDataReader databaseReader;
        private OleDbDataAdapter dataAdapter;
        #endregion

        #region Ctor
        public DatabaseProvider(string databaseConnectionString)
        {
            this.databaseConnectionString = databaseConnectionString;

            Console.WriteLine($"Database connection path - {databaseConnectionString}");
        }
        #endregion

        #region Method
        public void Fill(ref DataTable dataTable, string request)
        {
            try
            {
                using (databaseConnection = new OleDbConnection(databaseConnectionString))
                {
                    using (databaseCommand = new OleDbCommand(request, databaseConnection))
                    {
                        databaseConnection.Open();

                        dataAdapter = new OleDbDataAdapter(databaseCommand);

                        dataAdapter.Fill(dataTable);

                        databaseCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExecuteNonQuery(string request)
        {
            try
            {
                using (databaseConnection = new OleDbConnection(databaseConnectionString))
                {
                    using (databaseCommand = new OleDbCommand(request, databaseConnection))
                    {
                        databaseConnection.Open();

                        databaseCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool Exsist(string request)
        {
            try
            {
                using (databaseConnection = new OleDbConnection(databaseConnectionString))
                {
                    using (databaseCommand = new OleDbCommand(request, databaseConnection))
                    {
                        databaseConnection.Open();

                        using (databaseReader = databaseCommand.ExecuteReader()) 
                        {
                            if (databaseReader.HasRows)
                            {
                                return true;
                            }
                        } 

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        #endregion
    }
}
