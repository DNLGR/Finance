using Data.Models;
using System.ServiceModel;

namespace FinanceServices.Models
{
    public class ServerSession : Session
    {
        public OperationContext UserOperationContext { get; set; }
    }
}
