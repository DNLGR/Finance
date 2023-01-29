using FinanceServices.Components.Database;
using System.Data;
using System.Windows.Input;

namespace Client.Interfaces
{
    public interface IDatabaseContentControl
    {
        DatabaseTable DatabaseContent { get; }

        ICommand AddCommand { get; }

        ICommand EditCommand { get; }

        ICommand RemoveCommand { get; }

        void OnNavigate();
    }
}
