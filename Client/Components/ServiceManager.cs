namespace Client.Components
{
    public class ServiceManager : DatabaseHostService.IDatabaseServiceCallback
    {
        #region Var
        public DatabaseHostService.DatabaseServiceClient DatabaseServiceClient;
        #endregion

        #region Ctor
        public ServiceManager()
        {
            DatabaseServiceClient = new DatabaseHostService.DatabaseServiceClient(new System.ServiceModel.InstanceContext(this));
        }
        #endregion

        #region Methods
        public void DataCallBack(string obj)
        {

        }
        #endregion
    }
}
