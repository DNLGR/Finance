using Data.Models;
using System.Data;
using System.ServiceModel;

namespace FinanceServices.Interfaces
{
    [ServiceContract(CallbackContract =typeof(IDatabaseDataCallBack))]
    public interface IDatabaseService
    {
        [OperationContract]
        void Test(string message);

        [OperationContract]
        void Execute(string expression);

        [OperationContract]
        object ExecuteResult(string expression);

        [OperationContract]
        User ExsistUser(string logn, string password);

        [OperationContract]
        void AppendUser(User user);
    }

    public interface IDatabaseDataCallBack
    {
        [OperationContract(IsOneWay = true)]
        void DataCallBack(string obj);
    }
}
