using Data.Models;
using FinanceServices.Enum;
using FinanceServices.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace FinanceServices.Components
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DatabaseService : IDatabaseService
    {
        #region Var
        private List<Session> Sessions;

        private DatabaseProvider databaseProvider;
        #endregion

        #region Ctors
        public DatabaseService()
        {
            Sessions = new List<Session>();

            databaseProvider = new DatabaseProvider();
        }
        #endregion

        #region Methods
        public int Connect(int ApplicationHashCode)
        {
            var obj = new Session() { SessionCode = Sessions.Count + 1, AppHashCode = ApplicationHashCode };

            Sessions.Add(obj);

            return obj.SessionCode;
        }

        public void Disconnect(int ApplicationHashCode)
        {
            Sessions.Remove(Sessions.FirstOrDefault(x => x.AppHashCode == ApplicationHashCode));
        }

        public DatabaseConnectionStatus GetDatabaseConnectionStatus()
        {
            return databaseProvider.GetDatabaseConnectionStatus;
        }

        public DatabaseStatus GetDatabaseStatus()
        {
            return databaseProvider.GetDatabaseStatus;
        }

        //public string UserExist(User obj)
        //{
        //    string request = $"SELECT * FROM [Users] WHERE [User_login]='{obj.LoginHash}' AND [User_password]='{obj.PasswordHash}'";

        //    DatabaseAnswer _answer = new DatabaseAnswer() { Exception = new DatabaseException() };

        //    User _localUser = new User();

        //    try
        //    {
        //        using (databaseConnection = new OleDbConnection(connectionString))
        //        {
        //            using (databaseCommand = new OleDbCommand(request, databaseConnection))
        //            {
        //                databaseConnection.Open();

        //                var reader = databaseCommand.ExecuteReader();

        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        _localUser.DatabaseId = (int)reader.GetValue(0);
        //                        _localUser.FirstName = reader.GetValue(3).ToString();
        //                        _localUser.MiddleName = reader.GetValue(4).ToString();
        //                        _localUser.LastName = reader.GetValue(5).ToString();
        //                        _localUser.LoginHash = obj.LoginHash;
        //                        _localUser.PasswordHash = obj.PasswordHash;
        //                        _localUser.SecretCodeHash = reader.GetValue(6).ToString();
        //                    }

        //                    _answer.Exception = null;
        //                }
        //                else
        //                {
        //                    _answer.Exception.Description = "Пользователь не был найден, пожалуйста проверьте правильность ввода данных.";
        //                    _answer.Exception.Title = "Ошибка считывания данных";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _answer.Exception.Description = ex.Message;
        //        _answer.Exception.Title = "Ошибка считывания данных";
        //    }

        //    _answer.Parametr = _localUser;

        //    return JsonSerializer.Serialize<DatabaseAnswer>(_answer);
        //}

        //public void AppendUser(User user)
        //{
        //    string request = $"INSERT INTO [Users] ([User_login], [User_password], [User_first_name], [User_middle_name], [User_last_name], [User_secret_code]) VALUES" +
        //        $"(\'" + user.LoginHash + "\',\'" + user.PasswordHash + "\', \'" + user.FirstName + "\', \'" + user.MiddleName + "\', \'" + user.LastName + "\', \'" + user.SecretCodeHash + "\')";

        //    Execute(request);
        //}

        //public DatabaseAnswer Execute(string expresion)
        //{
        //    DatabaseAnswer Response;

        //    using (databaseConnection = new OleDbConnection(connectionString))
        //    {

        //        Response = new DatabaseAnswer();
        //        try
        //        {
        //            databaseConnection.Open();

        //            databaseCommand = new OleDbCommand(expresion, databaseConnection);

        //            Response.Parametr = databaseCommand.ExecuteNonQuery();

        //            Response.ParametrType = typeof(int);

        //            databaseConnection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Exception.Description = ex.Message;
        //        }
        //    }

        //    return Response;
        //}

        //public DatabaseAnswer ExecuteResult(string expresion)
        //{
        //    object response;

        //    using (databaseConnection = new OleDbConnection(connectionString))
        //    {
        //        databaseConnection.Open();

        //        databaseCommand = new OleDbCommand(expresion, databaseConnection);

        //        response = databaseCommand.ExecuteNonQuery();

        //        databaseConnection.Close();
        //    }

        //    return null;
        //}
        #endregion
    }
}
