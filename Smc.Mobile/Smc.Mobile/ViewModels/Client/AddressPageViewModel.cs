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
    public class AddressPageViewModel : BaseClientViewModel
    {

        private bool isLoading = false;
        public AddressPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IProxyClientApi proxyClient)
            : base(navigationService, busyService, pageDialogService, proxyClient)
        {

            this.PropertyChanged += AddressPageViewModel_PropertyChanged;
        }

        private void AddressPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "PhysicalAddressZipCode")
            {
                if (!String.IsNullOrEmpty(PhysicalAddressZipCode) && PhysicalAddressZipCode.Length == 5)
                {
                    if (isLoading)
                        return;
                    LoadZipCode(PhysicalAddressZipCode);
                }
            }
            else if (e.PropertyName == "PostalAddressZipCode")
            {
                if (!String.IsNullOrEmpty(PostalAddressZipCode) && PostalAddressZipCode.Length == 5)
                {
                    if (isLoading)
                        return;
                    LoadPostalZipCode(PostalAddressZipCode);
                }
            }
        }


        string physicalAddressLine1;
        public string PhysicalAddressLine1
        {
            get { return physicalAddressLine1; }
            set { SetProperty(ref physicalAddressLine1, value); }
        }

        string physicalAddressLine2;
        public string PhysicalAddressLine2
        {
            get { return physicalAddressLine2; }
            set { SetProperty(ref physicalAddressLine2, value); }
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


        string postalAddressLine1;
        public string PostalAddressLine1
        {
            get { return postalAddressLine1; }
            set { SetProperty(ref postalAddressLine1, value); }
        }

        string postalAddressLine2;
        public string PostalAddressLine2
        {
            get { return postalAddressLine2; }
            set { SetProperty(ref postalAddressLine2, value); }
        }

        string postalAddressZipCode;
        public string PostalAddressZipCode
        {
            get { return postalAddressZipCode; }
            set { SetProperty(ref postalAddressZipCode, value); }
        }


        string postalAddressCity;
        public string PostalAddressCity
        {
            get { return postalAddressCity; }
            set { SetProperty(ref postalAddressCity, value); }
        }

        string postalAddressState;
        public string PostalAddressState
        {
            get { return postalAddressState; }
            set { SetProperty(ref postalAddressState, value); }
        }

        public  void LoadZipCode(string zipCode)
        {

            Device.BeginInvokeOnMainThread( async () =>
            {
                using (this.BusyService.BeginBusy())
                {
                    var result = await proxyClient.GetRequestAsync<ZipCodeDto>($"{ApiConstants.ZipCode}{zipCode}");

                    if (result != null && result.Ack == AckCode.Success)
                    {
                        if (result.Data != null)
                        {
                            PhysicalAddressCity = result.Data.City;
                            PhysicalAddressState = result.Data.State;
                        }
                    }
                }

            });
        }

        public void LoadPostalZipCode(string zipCode)
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                using (this.BusyService.BeginBusy())
                {
                    var result = await proxyClient.GetRequestAsync<ZipCodeDto>($"{ApiConstants.ZipCode}{zipCode}");

                    if (result != null && result.Ack == AckCode.Success)
                    {
                        if (result.Data != null)
                        {
                            PostalAddressCity = result.Data.City;
                            PostalAddressState = result.Data.State;
                        }
                    }
                }

            });
        }

        public DelegateCommand SaveAndContinueCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    LoadClientModel();
                    NavigationParameters parameters = new NavigationParameters
                    {
                        { "clientModel", ClientModel }
                    };

                    await this.NavigationService.NavigateAsync("ContactInfoPage", null, false);

                });
            }
        }

        public DelegateCommand CopyAddressCommand
        {
            get
            {
                return new DelegateCommand( () =>
                {
                    isLoading = true;
                    this.PostalAddressLine1 = this.PhysicalAddressLine1;
                    this.PostalAddressLine2 = this.PhysicalAddressLine2;
                    this.PostalAddressZipCode = this.PhysicalAddressZipCode;
                    this.PostalAddressCity = this.PhysicalAddressCity;
                    this.PostalAddressState = this.PhysicalAddressState;
                    isLoading = false;
                });
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            isLoading = true;
            ClientModel = parameters.GetValue<ClientModel>("clientModel");
            if (ClientModel != null)
            {
                this.PhysicalAddressLine1 = ClientModel.PhysicalAddress1;
                this.PhysicalAddressLine2 = ClientModel.PhysicalAddress2;
                this.PhysicalAddressZipCode = ClientModel.PhysicalAddressZipCode;
                this.PhysicalAddressState = ClientModel.PhysicalAddressState;
                this.PhysicalAddressCity = ClientModel.PhysicalAddressCity;


                this.PostalAddressLine1 = ClientModel.PostalAddress1;
                this.PostalAddressLine2 = ClientModel.PostalAddress2;
                this.PostalAddressZipCode = ClientModel.PostalAddressZipCode;
                this.PostalAddressState = ClientModel.PostalAddressState;
                this.PostalAddressCity = ClientModel.PostalAddressCity;

            }
            isLoading = false;
        }


        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            LoadClientModel();

            parameters.Add("clientModel", ClientModel);

            base.OnNavigatedFrom(parameters);
        }

        private void LoadClientModel()
        {
            ClientModel.PhysicalAddress1 = this.PhysicalAddressLine1;
            ClientModel.PhysicalAddress2 = this.PhysicalAddressLine2;
            ClientModel.PhysicalAddressZipCode = this.PhysicalAddressZipCode;
            ClientModel.PhysicalAddressState = this.PhysicalAddressState;
            ClientModel.PhysicalAddressCity = this.PhysicalAddressCity;


            ClientModel.PostalAddress1 = this.PostalAddressLine1;
            ClientModel.PostalAddress2 = this.PostalAddressLine2;
            ClientModel.PostalAddressZipCode = this.PostalAddressZipCode;
            ClientModel.PostalAddressState = this.PostalAddressState;
            ClientModel.PostalAddressCity = this.PostalAddressCity;

        }
    }
}
