using System;

namespace Client
{
    public class ServiceManager : DatabaseHostService.IDatabaseServiceCallback
    {


        public DatabaseHostService.DatabaseServiceClient DatabaseServiceClient;

        public void DataCallBack(string obj)
        {
            
        }

        public ServiceManager()
        {
            DatabaseServiceClient = new DatabaseHostService.DatabaseServiceClient(new System.ServiceModel.InstanceContext(this));
        }
    }
}
