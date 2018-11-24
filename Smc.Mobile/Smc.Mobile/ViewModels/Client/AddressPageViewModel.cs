using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Smc.Mobile.Api;
using Smc.Mobile.Api.Dto;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smc.Mobile.ViewModels.Client
{
    public class AddressPageViewModel : ViewModelBase
    {

        private IProxyClientApi proxyClient;
        public AddressPageViewModel(INavigationService navigationService, IBusyService busyService, IProxyClientApi proxyClient)
        : base(navigationService, busyService)
        {
            this.proxyClient = proxyClient;
            Title = "Bienvenido";

            this.PropertyChanged += AddressPageViewModel_PropertyChanged;
        }

        private void AddressPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "PhysicalAddressZipCode")
            {
                if (!String.IsNullOrEmpty(PhysicalAddressZipCode) && PhysicalAddressZipCode.Length == 5)
                {
                    LoadZipCode(PhysicalAddressZipCode);
                }
            }
        }

        string physicalAddressZipCode;
        public string PhysicalAddressZipCode
        {
            get { return physicalAddressZipCode; }
            set { SetProperty(ref physicalAddressZipCode, value); }
        }


        string physicalAddressCity;
        public string PhysicalAddressCity
        {
            get { return physicalAddressCity; }
            set { SetProperty(ref physicalAddressCity, value); }
        }

        string physicalAddressState;
        public string PhysicalAddressState
        {
            get { return physicalAddressState; }
            set { SetProperty(ref physicalAddressState, value); }
        }

        public DelegateCommand SaveAndContinueCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await this.NavigationService.NavigateAsync("ContactInfoPage", null, false);

                });
            }
        }

        public async void LoadZipCode(string zipCode)
        {
            var result = await proxyClient.GetRequestAsync<ZipCodeDto>($"{ApiConstants.ZipCode}{zipCode}");

            //if (result.Ack == AckCode.Success)
            //{
            //    if (result.Data != null)
            //    {
            //    }
            //}
        }
    }
}
