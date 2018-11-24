using SignaturePad.Forms;
using System;
using Xamarin.Forms;

namespace Smc.Mobile.Views.Signature
{
    public partial class SignaturePadPage : ContentPage
    {

        //private SignaturePadView signaturePadView;
        public SignaturePadPage()
        {
            InitializeComponent();
            UpdateControls();

           // signaturePadView = new SignaturePadView();

            //padContainer.
                //  < controls:SignaturePadView
                // x:Name = "signatureView" StrokeCompleted = "SignatureChanged" Cleared = "SignatureChanged"
                //CaptionTextColor = "#B8860B" ClearTextColor = "#B8860B" PromptTextColor = "#B8860B"
                //SignatureLineColor = "#B8860B" BackgroundColor = "#FAFAD2" />

        }

        private void UpdateControls()
        {
            btnSave.IsEnabled = !signatureView.IsBlank;
            btnSaveImage.IsEnabled = !signatureView.IsBlank;
           // btnLoad.IsEnabled = points != null;
        }

        private void SaveVectorClicked(object sender, EventArgs e)
        {
            //points = signatureView.Points.ToArray();
            UpdateControls();

            DisplayAlert("Signature Pad", "Vector signature saved to memory.", "OK");
        }

        private void LoadVectorClicked(object sender, EventArgs e)
        {
           // signatureView.Points = points;
        }

        private async void SaveImageClicked(object sender, EventArgs e)
        {
            bool saved;
            using (var bitmap = await signatureView.GetImageStreamAsync(SignatureImageFormat.Png, Color.Black, Color.White, 1f))
            {
               // saved = await App.SaveSignature(bitmap, "signature.png");
            }

            //if (saved)
            //    await DisplayAlert("Signature Pad", "Raster signature saved to the photo library.", "OK");
            //else
            //    await DisplayAlert("Signature Pad", "There was an error saving the signature.", "OK");
        }

        private void SignatureChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }
    }
}
