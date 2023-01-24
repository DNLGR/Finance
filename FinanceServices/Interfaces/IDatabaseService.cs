using FinanceServices.Enum;
using System.ServiceModel;

namespace FinanceServices.Interfaces
{
    [ServiceContract(CallbackContract =typeof(IDatabaseDataCallBack))]
    public interface IDatabaseService
    {
        [OperationContract]
        int Connect(int ApplicationHashCode);

        [OperationContract]
        void Disconnect(int ApplicationHashCode);

        [OperationContract]
        DatabaseConnectionStatus GetDatabaseConnectionStatus();

        [OperationContract]
        DatabaseStatus GetDatabaseStatus();
    }

    public interface IDatabaseDataCallBack
    {
        [OperationContract(IsOneWay = true)]
        void DataCallBack(string obj);
    }
}
