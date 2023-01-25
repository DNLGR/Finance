using Client.Components;
using FinanceServices;
using System;
using System.Data;
using System.Text.Json;
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

                //Core.GetInstance().GetFinanceDataSet = JsonSerializer.Deserialize<Finance_dbDataSet>(Core.GetInstance().GetServiceManager.DatabaseServiceClient.GetDataSet());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
            finally
            {
                Core.GetInstance().Connect(GetHashCode());
            }

            new MainWindow().Show();
        }
    }
}
