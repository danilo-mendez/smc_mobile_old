using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Smc.Mobile.Controls
{
    public class ProfileNavbar: SfSegmentedControl
    {

        public ProfileNavbar()
            :base()
        {
            this.ItemsSource = new List<String>
            {
                "Perfil", "Demografia", "Direccion", "Contacto"
            };

            
            this.HeightRequest = 80;
            this.VisibleSegmentsCount = 4;
            this.BorderColor = Color.FromHex("#929292");
            this.FontColor = Color.FromHex("#929292");
            this.SelectionTextColor = Color.FromHex("#87A3BA");
            this.Color = Color.Transparent;
            this.BackgroundColor = Color.Transparent;
            this.SelectionIndicatorSettings = new SelectionIndicatorSettings()
            {
                Position = SelectionIndicatorPosition.Bottom
            };

        }

        public int SelectedPage
        {
            set
            {
                this.SelectedIndex = value;
            }
        }
    }
}
