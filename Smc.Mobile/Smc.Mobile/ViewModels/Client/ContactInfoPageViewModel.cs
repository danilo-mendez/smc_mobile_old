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
	public class ContactInfoPageViewModel : BaseClientViewModel
    {
        public ContactInfoPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IProxyClientApi proxyClient)
            : base(navigationService, busyService, pageDialogService, proxyClient)
        {

         
        }

        String telephone1;
        public String Telephone1
        {
            get { return telephone1; }
            set { SetProperty(ref telephone1, value); }
        }

        IdNameModel telephoneType1;
        public IdNameModel TelephoneType1
        {
            get { return telephoneType1; }
            set { SetProperty(ref telephoneType1, value); }
        }


        String email;
        public String Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }


        IdNameModel driverLicense;
        public IdNameModel DriverLicense
        {
            get { return driverLicense; }
            set { SetProperty(ref driverLicense, value); }
        }


        IdNameModel driverLicenseCategory;
        public IdNameModel DriverLicenseCategory
        {
            get { return driverLicenseCategory; }
            set { SetProperty(ref driverLicenseCategory, value); }
        }


        IdNameModel highestEducationalLevelCompleted;
        public IdNameModel HighestEducationalLevelCompleted
        {
            get { return highestEducationalLevelCompleted; }
            set { SetProperty(ref highestEducationalLevelCompleted, value); }
        }


        public DelegateCommand SaveAndContinueCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    await this.pageDialogService.DisplayAlertAsync("Alerta", "Seguro social inválido", "OK");
                });
            }
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ClientModel = parameters.GetValue<ClientModel>("clientModel");
            if (ClientModel != null)
            {
                this.Telephone1 = ClientModel.Telephone1;
                this.Email = ClientModel.Email;

                if (ClientModel.TelephoneType1.HasValue)
                {
                    this.TelephoneType1 = this.PhoneTypeList.FirstOrDefault(r => r.Id == ClientModel.TelephoneType1);
                }
                if (ClientModel.DriverLicense.HasValue)
                {
                    this.DriverLicense = this.YesNoNotIdentifyList.FirstOrDefault(r => r.Id == ClientModel.DriverLicense);
                }
                if (ClientModel.DriverLicenseCategory.HasValue)
                {
                    this.DriverLicenseCategory = this.LicenseCategoryList.FirstOrDefault(r => r.Id == ClientModel.DriverLicenseCategory);
                }
                if (ClientModel.HighestEducationalLevelCompleted.HasValue)
                {
                    this.HighestEducationalLevelCompleted = this.HighestEducationalLevelCompletedList.FirstOrDefault(r => r.Id == ClientModel.HighestEducationalLevelCompleted);
                }
            }
        }


        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            LoadClientModel();

            parameters.Add("clientModel", ClientModel);

            base.OnNavigatedFrom(parameters);
        }

        private void LoadClientModel()
        {
            ClientModel.Telephone1 = this.Telephone1;
            ClientModel.Email = this.Email;
            ClientModel.TelephoneType1 = this.TelephoneType1 != null ? this.TelephoneType1.Id : new Nullable<int>();
            ClientModel.DriverLicense = this.DriverLicense != null ? this.DriverLicense.Id : new Nullable<int>();
            ClientModel.DriverLicenseCategory = this.DriverLicenseCategory != null ? this.DriverLicenseCategory.Id : new Nullable<int>();
            ClientModel.HighestEducationalLevelCompleted = this.HighestEducationalLevelCompleted != null ? this.HighestEducationalLevelCompleted.Id : new Nullable<int>();

        }


    }
}
