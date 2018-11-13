using System.Collections.Generic;
using Xamarin.Forms;

namespace Smc.Mobile.Views.Client
{
    public partial class ContactInfoPage : ContentPage
    {
        public ContactInfoPage()
        {
            InitializeComponent();

            wizardNav.ItemsSource = new List<string>
                {
                    "1","2","3","4","5","6"
                };
        }
    }
}
