using Client.ViewModels;

namespace Client.Components
{
    public class Core
    {
        #region Var
        private static Core coreInstance;
        private static ServiceProvider serviceInstance;
        private static NavigationStore navigatorInstance;
        #endregion

        #region Methods
        public static Core GetInstance()
        {
            if (coreInstance == null)
            {
                coreInstance = new Core();
            }

            return coreInstance;
        }

        public static ServiceProvider GetServiceInstance()
        {
            if (serviceInstance == null)
            {
                serviceInstance = new ServiceProvider();
            }

            return serviceInstance;
        }

        public static NavigationStore GetNavigatorInstance()
        {
            if (navigatorInstance == null)
            {
                navigatorInstance = new NavigationStore();
            }

            return navigatorInstance;
        }
        #endregion
    }
}
