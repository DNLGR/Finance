using System;

namespace FinanceServices.Components
{
    public class DatabaseRequest
    {
        public string Query { get; set; }

        public Type Table_type { get; set; }

        public int Column_count { get; set; }
    }
}
