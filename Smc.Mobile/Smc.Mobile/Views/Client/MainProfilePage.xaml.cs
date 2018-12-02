using Syncfusion.XForms.Buttons;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Smc.Mobile.Views.Client
{
    public partial class MainProfilePage : ContentPage
    {
        public MainProfilePage()
        {
            InitializeComponent();


            //wizardNav.ItemsSource = new ObservableCollection<SfSegmentItem>
            //{
            //new SfSegmentItem(){IconFont = "2", FontIconFontColor=Color.FromHex("#000000"), FontColor=Color.FromHex("#000000"), Text = "Day"},
            //new SfSegmentItem(){IconFont = "3",  FontIconFontColor=Color.FromHex("#000000"),  FontColor=Color.FromHex("#000000"), Text = "Week"},
            //new SfSegmentItem(){IconFont = "\\e701",  FontIconFontColor=Color.FromHex("#000000"),  FontColor=Color.FromHex("#000000"), Text = "Month" }
            //};

            //wizardNav.DisplayMode = SegmentDisplayMode.ImageWithText;
            //wizardNav.SelectedIndex = 1;
            //wizardNav.VisibleSegmentsCount = 3;
            //wizardNav.SelectionTextColor = Color.FromHex("#000000");
            //wizardNav.FontIconFontFamily = "materialdesignicons-webfont.ttf";

            //picker.PickerMode = Syncfusion.SfPicker.XForms.PickerMode.Dialog;
            //picker.SelectionChanged += Picker_SelectionChanged;
        }

        //private void Picker_SelectionChanged(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
        //{
        //    picker.IsOpen = false;
        //}

        //public void StartCall(object sender, EventArgs args)
        //{
        //    picker.IsOpen = true;
        //}
    }
}
