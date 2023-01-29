using Client.Components;
using Client.ViewModels;
using DevExpress.Mvvm;
using System.Windows;

namespace Client
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new MainWindow().Show();            
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            //Core.GetInstance().GetServiceManager.Disconnect();
        }
    }
}
