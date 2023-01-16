using Data.Models;
using FinanceServices.Interfaces;
using FinanceServices.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;
using System.ServiceModel;

namespace FinanceServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DatabaseService : IDatabaseService
    {
        #region Var
        private List<ServerUser> UserSession;
        private string connectionString = string.Empty;
        private OleDbConnection databaseConnection;
        private OleDbCommand databaseCommand;
        #endregion

        #region Ctors
        public DatabaseService()
        {
            UserSession = new List<ServerUser>();

            connectionString = string.Empty;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultDatabaseConnection"].ToString();
        }
        #endregion

        #region Methods
        public void Test(string message)
        {
            Debug.WriteLine($"\n\n\n {message} \n\n\n");
        }

        public User ExsistUser(string login, string password)
        {
            string request = $"SELECT COUNT(*) FROM [Users] WHERE [User_login]='{login}' AND [User_password]='{password}'";

            User localUser = null;

            using (databaseConnection = new OleDbConnection(connectionString))
            {
                using (databaseCommand = new OleDbCommand(request, databaseConnection))
                {
                    databaseConnection.Open();

                    var reader = databaseCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            localUser = new User()
                            {
                                Id = Convert.ToInt32(reader.GetValue(0)),
                                FirstName = Convert.ToString(reader.GetValue(1)),
                                LastName = Convert.ToString(reader.GetValue(2)),
                                Login = login,
                                Password = password
                            };
                        }
                    }
                    else
                    {
                        localUser = null;
                    }

                    reader.Close();
                }
            }

            return localUser;
        }

        public void AppendUser(User user)
        {
            string request = $"INSERT INTO [Users] ([User_login], [User_password], [User_first_name], [User_last_name]) VALUES " +
                $"('" + user.Login + "','" + user.Password + "', '" + user.FirstName + "', '" + user.LastName + "')";

            Execute(request);
        }

        public void Execute(string expresion)
        {
            using (databaseConnection = new OleDbConnection(connectionString))
            {
                databaseConnection.Open();

                databaseCommand = new OleDbCommand(expresion, databaseConnection);

                databaseCommand.ExecuteNonQuery();

                databaseConnection.Close();
            }
        }

        public object ExecuteResult(string expresion)
        {
            object response;

            using (databaseConnection = new OleDbConnection(connectionString))
            {
                databaseConnection.Open();

                databaseCommand = new OleDbCommand(expresion, databaseConnection);

                response = databaseCommand.ExecuteNonQuery();

                databaseConnection.Close();
            }

            return response;
        }
        #endregion
    }
}
