﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SignaturePad.Forms;
using Smc.Mobile.Api;
using Smc.Mobile.Api.Dto;
using Smc.Mobile.Controls;
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
        protected IPageDialogService pageDialogService;

        public SignaturePadPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IApiService apiService)
            : base(navigationService, busyService)
        {
            this.apiService = apiService;
            this.pageDialogService = pageDialogService;

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
                                            Xamarin.Forms.DependencyService.Get<IMessage>().LongAlert("Firma sometida exitosamente"); 

                                            await this.NavigationService.GoBackAsync();
                                        }
                                        else
                                        {

                                            await this.pageDialogService.DisplayAlertAsync("Alerta", postSignature.Message, "OK");

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
