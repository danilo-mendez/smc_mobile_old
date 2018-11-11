using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Smc.Mobile.Views.Client
{
    public class CreateClientNavigationPage: NavigationPage
    {
        public CreateClientNavigationPage()
        {
            this.BarBackgroundColor = (Color)Application.Current.Resources["PrimarBackground"];
        }
    }
}
