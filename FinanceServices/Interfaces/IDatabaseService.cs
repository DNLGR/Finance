using FinanceServices.Components.Database;
using System.ServiceModel;

namespace FinanceServices.Interfaces
{
    [ServiceContract]
    public interface IDatabaseService
    {
        [OperationContract]
        int Connect(int ApplicationHashCode);

        [OperationContract]
        void Disconnect(int ApplicationHashCode);



        [OperationContract]
        DatabaseTable Get(string tableName);

        [OperationContract]
        void Execute(string request);

        [OperationContract]
        bool Exsist(string request);
    }
}
