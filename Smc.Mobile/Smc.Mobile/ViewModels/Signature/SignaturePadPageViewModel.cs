using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SignaturePad.Forms;
using Smc.Mobile.Api;
using Smc.Mobile.Api.Dto;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels
{
	public class SignaturePadPageViewModel : ViewModelBase
    {
        private IApiService apiService;

        public SignaturePadPageViewModel(INavigationService navigationService, IBusyService busyService, IApiService apiService)
            : base(navigationService, busyService)
        {
            this.apiService = apiService;
      
        }


        public Func<SignatureImageFormat, ImageConstructionSettings, Task<Stream>> GetImageStreamAsync { get; set; }

        public DelegateCommand SaveSignatureCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        using (this.BusyService.BeginBusy())
                        {
                            try { 
                            var settings = new ImageConstructionSettings
                            {
                                StrokeColor = Color.Black,
                                BackgroundColor = Color.White,
                                StrokeWidth = 1f
                            };


                                using (var bitmap = await GetImageStreamAsync(SignatureImageFormat.Png, settings))
                                {
                                    using (var memoryStream = new MemoryStream())
                                    {
                                        bitmap.CopyTo(memoryStream);
                                        bitmap.Dispose();
                                        var data = memoryStream.ToArray();

                                        var postSignature = await this.apiService.Sign(data);

                                        if (postSignature.ResponseCode == ResponseCodes.Success)
                                        {
                                            Acr.UserDialogs.UserDialogs.Instance.Toast("Firma sometida exitosamente");

                                            await this.NavigationService.GoBackAsync();
                                        }
                                        else
                                        {
                                            DisplayeAlert(postSignature.Message);
                                        } 
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                HandleException(ex);
                            }

                        }

                    });
                });
            }
 
        }


    }
}
