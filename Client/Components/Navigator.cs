using Client.View.Pages;
using Client.View.Pages.Database;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Client.Components
{
    public class Navigator
    {
        #region Private var
        private List<ClientPage> pages;

        private Frame contentFrameNavigator;
        #endregion

        #region Ctor
        public Navigator()
        {
            pages = new List<ClientPage>()
            {
                new ClientPage() { Title = "Login", Content = new Login() },
                new ClientPage() { Title = "Register", Content = new Register() },
                new ClientPage() { Title = "SecretCode", Content = new SecretCode() },
                new ClientPage() { Title = "Content", Content = new Content() },
                new ClientPage() { Title = "Append", Content = new Append() },
                new ClientPage() { Title = "DBBalance", Content = new DBBalance() },
                new ClientPage() { Title = "DBCategories", Content = new DBCategories() },
                new ClientPage() { Title = "DBCompany", Content = new DBCompany() },
                new ClientPage() { Title = "DBDescription", Content = new DBDescription() },
                new ClientPage() { Title = "DBFactors", Content = new DBFactors() },
                new ClientPage() { Title = "DBLeaders", Content = new DBLeaders() },
                new ClientPage() { Title = "DBPropertyes", Content = new DBPropertyes() },
                new ClientPage() { Title = "DBUsers", Content = new DBUsers() }
            };
        }
        #endregion

        #region Public Methods
        public void SetContentFrame(ref Frame obj)
        {
            contentFrameNavigator = obj;
        }

        public void Navigate(string obj)
        {
            if (obj is null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(obj))
            {
                return;
            }

            contentFrameNavigator.Navigate(pages.FirstOrDefault(x => x.Title == obj).Content);
        }

        public void Navigate(Frame contentFrame, string obj)
        {
            if (obj is null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(obj))
            {
                return;
            }

            contentFrame.Navigate(pages.FirstOrDefault(x => x.Title == obj).Content);
        }

        public void NavigateNew(ClientPage obj)
        {
            if (obj is null)
            {
                return;
            }

            if (pages.Contains(obj))
            {
                Update(pages.FirstOrDefault(x => x == obj));
            }
            else
            {
                pages.Append(obj);
            }

            Navigate(obj.Title);
        }

        private void Update(ClientPage obj)
        {
            foreach (var item in pages)
            {
                if (item.Title == obj.Title)
                {
                    item.Content = obj.Content;

                    break;
                }
            }
        }
        #endregion
    }
}
