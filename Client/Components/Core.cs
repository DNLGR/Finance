using Data.Models;
using System;
using System.Data;
using System.Text.Json;

namespace Client.Components
{
    public class Core
    {
        #region Public Propertyes
        public string GetCurrentDirectory
        {
            get => Environment.CurrentDirectory;
        }

        //public User GetUser 
        //{ 
        //    get
        //    {
        //        if (user == null)
        //        {
        //            return null;
        //        }
                
        //        return user;
        //    }
        //}

        //public User SetUser
        //{
        //    set
        //    {
        //        if (value is null)
        //        {
        //            return;
        //        }

        //        if (string.IsNullOrEmpty(value.LoginHash) && string.IsNullOrEmpty(value.PasswordHash))
        //        {
        //            return;
        //        }

        //        if (string.IsNullOrEmpty(value.SecretCodeHash))
        //        {
        //            return;
        //        }

        //        user = value;
        //    }
        //}

        public ServiceManager GetServiceManager
        {
            get => serviceManager;
        }

        public Navigator GetNavigator
        {
            get => navigatorManager;
        }

        public DataSet GetFinanceDataSet { get; set; }
        #endregion

        #region Private var
        private static Core instance;
        //private User user;
        private ServiceManager serviceManager;
        private Navigator navigatorManager;
        private int applicationHashCode;
        #endregion

        #region Ctor
        private Core()
        {
            serviceManager = new ServiceManager();

            navigatorManager = new Navigator();
        }
        #endregion

        #region Methods
        public static Core GetInstance()
        {
            if (instance == null)
            {
                instance = new Core();
            }

            return instance;
        }

        public void Connect(int value)
        {
            applicationHashCode = value;
        }



        public string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }

        public T DeSerialize<T>(string obj)
        {
            return JsonSerializer.Deserialize<T>(obj);
        }
        #endregion
    }
}
