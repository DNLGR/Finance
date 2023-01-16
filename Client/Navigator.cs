using System.Windows.Controls;

namespace Client
{
    public static class Navigator
    {
        private static Frame contentFrameNavigator;
        private static Page lastPageNavigation;

        public static void SetContentFrame(ref Frame obj)
        {
            contentFrameNavigator = obj;
        }

        public static void Navigate(Page obj)
        {
            lastPageNavigation = (Page)contentFrameNavigator.Content;

            contentFrameNavigator.Navigate(obj);
        }

        public static void GoBack()
        {
            Navigate(lastPageNavigation);
        }
    }
}
