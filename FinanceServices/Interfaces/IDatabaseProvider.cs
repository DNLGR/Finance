using System.Data;

namespace FinanceServices.Interfaces
{
    public interface IDatabaseProvider
    {
        void Fill(ref DataTable dataTable, string request);

        void ExecuteNonQuery(string request);

        bool Exsist(string request);
    }
}
