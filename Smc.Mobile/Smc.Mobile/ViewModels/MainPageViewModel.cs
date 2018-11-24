﻿using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Smc.Mobile.Api;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IApiService apiService;
        public MainPageViewModel(INavigationService navigationService, IBusyService busyService, IApiService apiService)
            : base(navigationService, busyService)
        {
            this.apiService = apiService;
            Title = "Bienvenido";

            LoadData();
        }

        string tabletInfo;
        public string TabletInfo
        {
            get { return tabletInfo; }
            set { SetProperty(ref tabletInfo, value); }
        }

        private void LoadData()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                using (this.BusyService.BeginBusy())
                {
                    try
                    {
                        var result = await apiService.GetRegistrationInfo();

                        if (result.ResponseCode != ResponseCodes.Success)
                        {
                            DisplayeAlert(result.Message);
                        }
                        else
                        {
                            if (result.Data.Id == 0)
                            {
                                var promptConfig = new PromptConfig
                                {
                                    InputType = InputType.Name,
                                    IsCancellable = false,
                                    Message = "Ingrese codigo tableta"
                                };

                                var dialogResult = await UserDialogs.Instance.PromptAsync(promptConfig);
                                if (dialogResult.Ok)
                                {
                                    if (!String.IsNullOrEmpty(dialogResult.Text))
                                    {
                                        var registerResult = await apiService.Register(dialogResult.Text);
                                        if (registerResult.ResponseCode == ResponseCodes.Success)
                                        {
                                            await UserDialogs.Instance.AlertAsync("Tableta Registrada exitosamente");
                                        }
                                        else
                                        {
                                            DisplayeAlert(registerResult.Message);
                                        }
                                    }

                                }

                            }
                            else
                            {
                                TabletInfo = $"Tablet: {result.Data.Name}, id: {result.Data.InternalId}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }

                }

            });
        }


        public DelegateCommand GotoRegisterClientCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    //Navegacion absolute
                    //Para navegacion no absoluta  NavigationPage/StartPage
                    await this.NavigationService.NavigateAsync("/CreateClientNavigationPage/WelcomePage", null, false);

                });
            }
        }

        public DelegateCommand GotoSignaturePadCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        var response = await this.apiService.GetPendingSignatureInfo();
                        if (response.Data != null && response.Data.Id > 0)
                        {
                            await this.NavigationService.NavigateAsync("SignaturePadPage", null, false);
                        }
                        else
                        {
                            DisplayeAlert("No existe reporte pendiente para esta tablet");
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
