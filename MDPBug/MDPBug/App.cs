using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MDPBug
{
    public class App : Application
    {
        private NavigationPage _navPage;
        public App()
        {
            var mdp = new MasterPage();
             _navPage = new NavigationPage(new MainPage());
             mdp.Detail = _navPage;

            NavigationPage.SetHasBackButton(mdp.Detail, false);
            NavigationPage.SetHasNavigationBar(mdp.Detail, false);
            NavigationPage.SetBackButtonTitle(mdp.Detail, "Badjoras");

            NavigateLater();

            MainPage = mdp;
        }

        async Task NavigateLater()
        {
            bool clearBackstack = true;
                await Task.Delay(2000);
                await _navPage.PushAsync(new SecondPage(), true);
                //    .ContinueWith(t =>
                //{
                //    if (!t.IsFaulted && clearBackstack)
                //    {
                //        var nav = _navPage.Navigation;
                //        do
                //        {
                //            nav.RemovePage(nav.NavigationStack[0]);
                //        } while (nav.NavigationStack.Count != 1);
                //    }

                //});

                NavigationPage.SetHasBackButton(_navPage, false);
                NavigationPage.SetHasNavigationBar(_navPage, false);
                NavigationPage.SetBackButtonTitle(_navPage, "Badjoras");

        }

    }
}
