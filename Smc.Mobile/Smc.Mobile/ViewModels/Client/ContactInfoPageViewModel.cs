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
        public IApiService apiService;
        public ContactInfoPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IProxyClientApi proxyClient, IApiService apiService)
            : base(navigationService, busyService, pageDialogService, proxyClient)
        {
            this.apiService = apiService;
         
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

                    LoadClientModel();

                    var dto = new ClientDto();

                    dto.FirstName = ClientModel.FirstName;
                    dto.LastName = ClientModel.LastName;
                    dto.SecondLastName = ClientModel.SecondLastName;
                    dto.SecondName = ClientModel.SecondName;
                    dto.ClientSSN = ClientModel.ClientSSN;

                    dto.Sex = ClientModel.Sex;
                    dto.DateofBirth = ClientModel.DateofBirth;
                    dto.Citizen = ClientModel.Citizen;
                    dto.SelectiveService = ClientModel.SelectiveService;

                    dto.PhysicalAddress1 = ClientModel.PhysicalAddress1;
                    dto.PhysicalAddress2 = ClientModel.PhysicalAddress2;
                    dto.PhysicalAddressZipCode = ClientModel.PhysicalAddressZipCode;
                    dto.PhysicalAddressState = ClientModel.PhysicalAddressState;
                    dto.PhysicalAddressCity = ClientModel.PhysicalAddressCity;

                    dto.PostalAddress1 = ClientModel.PostalAddress1;
                    dto.PostalAddress2 = ClientModel.PostalAddress2;
                    dto.PostalAddressZipCode = ClientModel.PostalAddressZipCode;
                    dto.PostalAddressState = ClientModel.PostalAddressState;
                    dto.PostalAddressCity = ClientModel.PostalAddressCity;


                    dto.Telephone1 = ClientModel.Telephone1;
                    dto.TelephoneType1 = ClientModel.TelephoneType1;
                    dto.Email = ClientModel.Email;
                    dto.DriverLicense = ClientModel.DriverLicense;
                    dto.DriverLicenseCategory = ClientModel.DriverLicenseCategory;
                    dto.HighestEducationalLevelCompleted = ClientModel.HighestEducationalLevelCompleted;

                    dto.EthnicityHispanicLatino = ClientModel.EthnicityHispanicLatino;
                    dto.AmericanIndianAlaskaNative = ClientModel.AmericanIndianAlaskaNative;
                    dto.Asian = ClientModel.Asian;
                    dto.BlackAfricanAmerican = ClientModel.BlackAfricanAmerican;
                    dto.NativeHawaiianOtherPacificIslander = ClientModel.NativeHawaiianOtherPacificIslander;
                    dto.White = ClientModel.White;
                    dto.Purpose = ClientModel.Purpose;

                    var registerResult = await apiService.SaveClient(dto);

                    if (registerResult.ResponseCode == ResponseCodes.Success)
                    {

                        await this.pageDialogService.DisplayAlertAsync("Alerta", "Cliente registrado exitosamente", "OK");


                        await this.NavigationService.NavigateAsync("/CreateClientNavigationPage/WelcomePage", null, false);

                    }
                    else
                    {
                        await this.pageDialogService.DisplayAlertAsync("Error", registerResult.Message, "OK");
                    }

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
