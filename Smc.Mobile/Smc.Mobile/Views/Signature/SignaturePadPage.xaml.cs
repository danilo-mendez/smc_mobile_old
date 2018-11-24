using SignaturePad.Forms;
using Smc.Mobile.ViewModels;
using System;
using System.IO;
using Xamarin.Forms;

namespace Smc.Mobile.Views.Signature
{
    public partial class SignaturePadPage : ContentPage
    {

        //private SignaturePadView signaturePadView;
        public SignaturePadPage()
        {
            InitializeComponent();

            SignaturePadPageViewModel model = (SignaturePadPageViewModel)this.BindingContext;
            model.GetImageStreamAsync = signatureView.GetImageStreamAsync;

        }
      
    }
}
