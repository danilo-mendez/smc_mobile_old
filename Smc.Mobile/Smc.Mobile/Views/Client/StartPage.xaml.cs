using Xamarin.Forms;

namespace Smc.Mobile.Views.Client
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
           // NavigationPage.SetHasNavigationBar(this, false);

        }

        private void Entry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 3)
            {
                Entry2.Focus();
            }
        }

        private void Entry2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 2)
            {
                Entry3.Focus();
            }
        }
    }
}
