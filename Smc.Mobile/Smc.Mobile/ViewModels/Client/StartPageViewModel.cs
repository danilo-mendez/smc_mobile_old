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
            Title = "SMC Mobile";
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

        IdNameModel purpose;
        public IdNameModel Purpose
        {
            get { return purpose; }
            set { SetProperty(ref purpose, value); }
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
                                if(ssn.Length != 11)
                                {
                                    await this.pageDialogService.DisplayAlertAsync("Alerta", "Seguro social inválido", "OK");
                                }
                                else if (Purpose == null)
                                {
                                    await this.pageDialogService.DisplayAlertAsync("Alerta", "Ingrese porpósito de su visita", "OK");
                                }
                                else
                                {
                                    var clientModel = new ClientModel();

                                    var result = await proxyClient.GetRequestAsync<ClientDto>($"{ApiConstants.GetClient}{ssn}");
                                    if (result != null && result.Ack == AckCode.Success)
                                    {
                                        if (result.Data != null && result.Data.ClientId > 0)
                                        {
                                            var entity = result.Data;

                                            clientModel.FirstName = entity.FirstName;
                                            clientModel.LastName = entity.LastName;
                                            clientModel.SecondLastName = entity.SecondLastName;
                                            clientModel.SecondName = entity.SecondName;
                                            clientModel.ClientSSN = entity.ClientSSN;

                                            clientModel.Sex = entity.Sex;
                                            clientModel.DateofBirth = entity.DateofBirth;
                                            clientModel.Citizen = entity.Citizen;
                                            clientModel.SelectiveService = entity.SelectiveService;

                                            clientModel.PhysicalAddress1 = entity.PhysicalAddress1;
                                            clientModel.PhysicalAddress2 = entity.PhysicalAddress2;
                                            clientModel.PhysicalAddressZipCode = entity.PhysicalAddressZipCode;
                                            clientModel.PhysicalAddressState = entity.PhysicalAddressState;
                                            clientModel.PhysicalAddressCity = entity.PhysicalAddressCity;

                                            clientModel.PostalAddress1 = entity.PostalAddress1;
                                            clientModel.PostalAddress2 = entity.PostalAddress2;
                                            clientModel.PostalAddressZipCode = entity.PostalAddressZipCode;
                                            clientModel.PostalAddressState = entity.PostalAddressState;
                                            clientModel.PostalAddressCity = entity.PostalAddressCity;


                                            clientModel.Telephone1 = entity.Telephone1;
                                            clientModel.TelephoneType1 = entity.TelephoneType1;
                                            clientModel.Email = entity.Email;
                                            clientModel.DriverLicense = entity.DriverLicense;
                                            clientModel.DriverLicenseCategory = entity.DriverLicenseCategory;
                                            clientModel.HighestEducationalLevelCompleted = entity.HighestEducationalLevelCompleted;

                                            clientModel.EthnicityHispanicLatino = entity.EthnicityHispanicLatino;
                                            clientModel.AmericanIndianAlaskaNative = entity.AmericanIndianAlaskaNative;
                                            clientModel.Asian = entity.Asian;
                                            clientModel.BlackAfricanAmerican = entity.BlackAfricanAmerican;
                                            clientModel.NativeHawaiianOtherPacificIslander = entity.NativeHawaiianOtherPacificIslander;
                                            clientModel.White = entity.White;

                                            await this.pageDialogService.DisplayAlertAsync("Alerta", "Hemos encontrado un cliente con esta información, en las pantallas siguientes usted podra editar para continuar con su registro", "Continuar");


                                        }

                                    }

                                    clientModel.ClientSSN = ssn;
                                    clientModel.Purpose = Purpose.Id;


                                    NavigationParameters parameters = new NavigationParameters
                                    {
                                        { "clientModel", clientModel }
                                    };

                                    await this.NavigationService.NavigateAsync("MainProfilePage", parameters, false);
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

