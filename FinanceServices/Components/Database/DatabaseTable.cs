using FinanceServices.Interfaces;
using System.Data;
using System.Runtime.Serialization;

namespace FinanceServices.Components.Database
{
    [DataContract]
    public class DatabaseTable : IDatabaseTable
    {
        [DataMember]
        public DataTable Table { get; set; }
    }
}
