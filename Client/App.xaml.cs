using Client.Components;
using System.Windows;

namespace Client
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            _ = Core.GetInstance();

            try
            {
                Core.GetInstance().Connect(Core.GetInstance().GetServiceManager.DatabaseServiceClient.Connect(GetHashCode()));
            }
            catch
            {

            }

            new MainWindow().Show();
        }
    }
}
