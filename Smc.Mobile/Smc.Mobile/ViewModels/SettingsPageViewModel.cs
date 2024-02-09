using Acr.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Smc.Mobile.Api;
using Smc.Mobile.Api.Dto;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels
{
	public class SettingsPageViewModel : ViewModelBase
    {
        private IApiService apiService;
        protected IPageDialogService pageDialogService;
        public SettingsPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IApiService apiService)
            : base(navigationService, busyService)
        {
            this.apiService = apiService;
            this.pageDialogService = pageDialogService;

            Title = "Setting";

            Url = ApiConstants.Baseurl; // CrossSettings.Current.Get<String>("Url", ApiConstants.Baseurl);
            TabletName =  CrossSettings.Current.Get<String>("TabletName", "");
            UseForSignature = CrossSettings.Current.Get<bool>("UseForSignature", true);
            UseForRegister = CrossSettings.Current.Get<bool>("UseForRegister", true);

        }

        string url;
        public string Url
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }

        string tabletName;
        public string TabletName
        {
            get { return tabletName; }
            set { SetProperty(ref tabletName, value); }
        }
        bool useForSignature;
        public bool UseForSignature
        {
            get { return useForSignature; }
            set { SetProperty(ref useForSignature, value); }
        }
        bool useForRegister;
        public bool UseForRegister
        {
            get { return useForRegister; }
            set { SetProperty(ref useForRegister, value); }
        }


        public  DelegateCommand SaveCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {

                        if (!String.IsNullOrEmpty(TabletName))
                        {
                            var registerResult = await apiService.Register(TabletName);
                            if (registerResult.ResponseCode == ResponseCodes.Success)
                            {
                                CrossSettings.Current.Set<String>("Url", Url);
                                CrossSettings.Current.Set<String>("TabletName", TabletName);
                                CrossSettings.Current.Set<bool>("UseForSignature", UseForSignature);
                                CrossSettings.Current.Set<bool>("UseForRegister", UseForRegister);

                                await this.pageDialogService.DisplayAlertAsync("Alerta", "Informacion actualizada", "OK");


                                await this.NavigationService.NavigateAsync("/CreateClientNavigationPage/MainPage", null, false);
                            }
                            else
                            {

                                await this.pageDialogService.DisplayAlertAsync("Alerta", registerResult.Message, "OK");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }

                });

            }
        }

    }
}
