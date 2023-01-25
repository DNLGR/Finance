using FinanceServices.Components;
using FinanceServices.Enum;
using System.Runtime.Serialization;
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

        [OperationContract]
        DatabaseProvider GetDatabaseProvider { get; }
    }

    public interface IDatabaseDataCallBack
    {
        [OperationContract(IsOneWay = true)]
        void DataCallBack(string obj);
    }
}
