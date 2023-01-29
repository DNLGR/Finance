using FinanceServices.Components.Database;
using FinanceServices.Interfaces;
using FinanceServices.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
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

        FileProvider fileProvider;
        #endregion

        #region Ctors
        public DatabaseService()
        {
            Sessions = new List<Session>();

            fileProvider = new FileProvider();

            databaseProvider = new DatabaseProvider("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\HP\\Desktop\\finance_main_db.mdb");
        }

        ~ DatabaseService()
        {
            fileProvider.Write($"{Environment.CurrentDirectory}\\log.txt", "null");
        }
        #endregion

        #region Methods
        public int Connect(int ApplicationHashCode)
        {
            foreach (var session in Sessions)
            {
                if (session.AppHashCode == ApplicationHashCode)
                {
                    Console.WriteLine($"User was connected to server, Session code: {session.SessionCode}, Application HashCode: {session.AppHashCode}");

                    return session.SessionCode;
                }
            }

            var obj = new Session() { SessionCode = Sessions.Count + 1, AppHashCode = ApplicationHashCode };

            Sessions.Add(obj);

            Console.WriteLine($"User was connected to server, Session code: {obj.SessionCode}, Application HashCode: {obj.AppHashCode}");

            return obj.SessionCode;
        }

        public void Disconnect(int ApplicationHashCode)
        {
            Console.WriteLine($"User was discennected from server - {ApplicationHashCode}");

            Sessions.Remove(Sessions.FirstOrDefault(x => x.AppHashCode == ApplicationHashCode));
        }

        public DatabaseTable Get(string tableName)
        {
            var obj = new DataTable(tableName);

            databaseProvider.Fill(ref obj, $"SELECT * FROM [{tableName}]");

            return new DatabaseTable() { Table = obj }; 
        }

        public void Execute(string request)
        {
            databaseProvider.ExecuteNonQuery(request);
        }

        public bool Exsist(string request)
        {
            return databaseProvider.Exsist(request);
        }
        #endregion
    }
}
