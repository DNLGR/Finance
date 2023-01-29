using System.Data;
using System.Runtime.Serialization;

namespace FinanceServices.Interfaces
{
    public interface IDatabaseTable 
    {
        [DataMember]
        DataTable Table { get; set; }
    }
}
