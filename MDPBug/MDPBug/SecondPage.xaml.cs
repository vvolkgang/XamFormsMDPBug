using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MDPBug
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            NavigationPage.SetBackButtonTitle(this, "Badjoras");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);

            //This is the only instruction that is having any effect, BUT, only when you navigate to the page. 
            //Doesn't work in the page that gets initialized
            NavigationPage.SetHasNavigationBar(this, false); 

            NavigationPage.SetBackButtonTitle(this, "Badjoras");
        }
    }
}
