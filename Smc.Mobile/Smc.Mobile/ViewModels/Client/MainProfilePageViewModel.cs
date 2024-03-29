﻿using Prism.Commands;
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
	public class MainProfilePageViewModel : BaseClientViewModel
    {
        public MainProfilePageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IProxyClientApi proxyClient)
            : base(navigationService, busyService, pageDialogService, proxyClient)
        {
            Title = "SMC Mobile";

        }

        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        string secondName;
        public string SecondName
        {
            get { return secondName; }
            set { SetProperty(ref secondName, value); }
        }


        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        string secondLastName;
        public string SecondLastName
        {
            get { return secondLastName; }
            set { SetProperty(ref secondLastName, value); }
        }

        IdNameModel gender;
        public IdNameModel Gender
        {
            get { return gender; }
            set { SetProperty(ref gender, value); }
        }

        string dob;
        public string Dob
        {
            get { return dob; }
            set { SetProperty(ref dob, value); }
        }

        IdNameModel citizen;
        public IdNameModel Citizen
        {
            get { return citizen; }
            set { SetProperty(ref citizen, value); }
        }

        IdNameModel selectiveService;
        public IdNameModel SelectiveService
        {
            get { return selectiveService; }
            set { SetProperty(ref selectiveService, value); }
        }


        public DelegateCommand SaveAndContinueCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    string vaidationMessage = Validate();

                    if (String.IsNullOrEmpty(vaidationMessage))
                    {
                        ClientModel.FirstName = this.FirstName;
                        ClientModel.SecondName = this.SecondName;
                        ClientModel.LastName = this.LastName;
                        ClientModel.SecondLastName = this.SecondLastName;

                        DateTime date;
                        if (DateTime.TryParse(this.Dob, out date))
                        {
                            ClientModel.DateofBirth = date;
                        }

                        ClientModel.Sex = this.Gender != null ? this.Gender.Id : new Nullable<int>();
                        ClientModel.Citizen = this.Citizen != null ? this.Citizen.Id : new Nullable<int>();
                        ClientModel.SelectiveService = this.SelectiveService != null ? this.SelectiveService.Id : new Nullable<int>();

                        NavigationParameters parameters = new NavigationParameters
                        {
                            { "clientModel", ClientModel }
                        };


                        await this.NavigationService.NavigateAsync("DemographicPage", parameters, false);
                    }
                    else
                    {
                        await this.pageDialogService.DisplayAlertAsync("Alerta", vaidationMessage, "OK");
                    }

                });
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ClientModel = parameters.GetValue<ClientModel>("clientModel");
            if (ClientModel != null)
            {
                this.FirstName = ClientModel.FirstName;
                this.LastName = ClientModel.LastName;
                this.SecondName = ClientModel.SecondName;
                this.SecondLastName = ClientModel.SecondLastName;


                if (ClientModel.DateofBirth.HasValue)
                {
                    var date = ClientModel.DateofBirth.Value;

                    var day = date.Day > 9 ? date.Day.ToString() : "0" + date.Day.ToString();
                    var month = date.Month > 9 ? date.Month.ToString() : "0" + date.Month.ToString();

                    this.Dob = $"{month}/{day}/{date.Year}";
                }

                if (ClientModel.Sex.HasValue)
                {
                    this.Gender = this.GenderList.FirstOrDefault(r => r.Id == ClientModel.Sex);
                }

                if (ClientModel.Citizen.HasValue)
                {
                    this.Citizen = this.YesNoNotIdentifyList.FirstOrDefault(r => r.Id == ClientModel.Citizen);
                }
                if (ClientModel.SelectiveService.HasValue)
                {
                    this.SelectiveService = this.YesNoNotIdentifyList.FirstOrDefault(r => r.Id == ClientModel.SelectiveService);
                }

            }
        }

        private string Validate()
        {
            string message = null;

            if (String.IsNullOrEmpty(this.FirstName))
            {
                message = "Primer Nombre es requerido";
            }
            else if (String.IsNullOrEmpty(this.LastName))
            {
                message = "Apellido Paterno es requerido";
            }
            else if (String.IsNullOrEmpty(this.Dob))
            {
                message = "Fecha Nacimiento es requerido";
            }
            else if (this.Gender == null)
            {
                message = "Sexo es requerido";
            }
            DateTime date;
            if (!DateTime.TryParse(this.Dob, out date))
            {
                message = "Fecha de nacimiento es invalida";
            }

            return message;
        }
  
    }
}
