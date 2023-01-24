using System;

namespace FinanceServices.Components
{
    public class DatabaseResponce
    {
        public DatabaseException Exception { get; set; }
        
        public object[] Values { get; set; }

        public Type ValueType { get; set; }

    }
}