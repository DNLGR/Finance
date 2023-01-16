using Data.Models;
using System.ServiceModel;

namespace FinanceServices.Models
{
    public class ServerUser : User
    {
        public OperationContext UserOperationContext { get; set; }
    }
}
