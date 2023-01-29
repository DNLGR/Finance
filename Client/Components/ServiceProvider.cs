using Client.Enum;
using FinanceServices.Models;
using System;
using System.Windows;

namespace Client.Components
{
    public class ServiceProvider
    {
        #region Var
        private Session currentSession;

        public DatabaseStatus DatabaseConnectionStatus { get; private set; } = DatabaseStatus.IsDisconnected;

        public DatabaseHostService.DatabaseServiceClient Service { get; private set; }
        #endregion

        #region Ctor
        public ServiceProvider()
        {
            try
            {
                Service = new DatabaseHostService.DatabaseServiceClient();

                Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nameof(ServiceProvider), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ~ ServiceProvider()
        {
            Disconnect();
        }
        #endregion

        #region Methods
        public void Connect()
        {
            if (DatabaseConnectionStatus == DatabaseStatus.IsDisconnected)
            {
                currentSession = new Session()
                {
                    AppHashCode = App.Current.GetHashCode()
                };

                if (Service.State == System.ServiceModel.CommunicationState.Closed)
                {
                    Service.Open();
                }

                currentSession.SessionCode = Service.Connect(currentSession.AppHashCode);

                DatabaseConnectionStatus = DatabaseStatus.IsConnected;
            }
        }

        public void Disconnect()
        {
            if (DatabaseConnectionStatus == DatabaseStatus.IsConnected) 
            {
                Service.Disconnect(currentSession.AppHashCode);

                DatabaseConnectionStatus = DatabaseStatus.IsDisconnected;

                currentSession = null;

                if (Service != null)
                {
                    Service.Close();
                }
            }
        }
        #endregion
    }
}
