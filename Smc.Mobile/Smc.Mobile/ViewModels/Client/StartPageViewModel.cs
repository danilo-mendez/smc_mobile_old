using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Smc.Mobile.Api;
using Smc.Mobile.Api.Dto;
using Smc.Mobile.Model;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels.Client
{
	public class StartPageViewModel : BaseClientViewModel
    {

        public StartPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IProxyClientApi proxyClient)
               : base(navigationService, busyService, pageDialogService, proxyClient)
        {
            Title = "Bienvenido";
        }

  

        string ssn1;
        public string SSN1
        {
            get { return ssn1; }
            set { SetProperty(ref ssn1, value); }
        }

        string ssn2;
        public string SSN2
        {
            get { return ssn2; }
            set { SetProperty(ref ssn2, value); }
        }

        string ssn3;
        public string SSN3
        {
            get { return ssn3; }
            set { SetProperty(ref ssn3, value); }
        }

        public DelegateCommand SearchAndContinueCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {

                    Device.BeginInvokeOnMainThread(async () =>
                    {

                        using (this.BusyService.BeginBusy())
                        {
                            try
                            {
                                string ssn = $"{SSN1}-{SSN2}-{SSN3}";
                                if (ssn != null && ssn.Length == 11)
                                {

                                    var result = await proxyClient.GetRequestAsync<ClientDto>($"{ApiConstants.ZipCode}{ssn}");

                                    if (result != null && result.Ack == AckCode.Success)
                                    {
                                        if (result.Data != null)
                                        {
                                            //PhysicalAddressCity = result.Data.City;
                                            //PhysicalAddressState = result.Data.State;
                                        }
                                    }

                                    var clientModel = new ClientModel();
                                    clientModel.ClientSSN = ssn;

                                    NavigationParameters parameters = new NavigationParameters
                                    {
                                        { "clientModel", clientModel }
                                    };

                                    await this.NavigationService.NavigateAsync("MainProfilePage", parameters, false);
                                }
                                else
                                {
                                    await this.pageDialogService.DisplayAlertAsync("Alerta", "Seguro social inválido", "OK");
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

