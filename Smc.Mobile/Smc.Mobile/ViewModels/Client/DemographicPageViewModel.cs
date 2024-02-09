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
	public class DemographicPageViewModel : BaseClientViewModel
    {

        public DemographicPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IProxyClientApi proxyClient)
        : base(navigationService, busyService, pageDialogService, proxyClient)
        {

        }

        bool ethnicityHispanicLatino;
        public bool EthnicityHispanicLatino
        {
            get { return ethnicityHispanicLatino; }
            set { SetProperty(ref ethnicityHispanicLatino, value); }
        }

        bool americanIndianAlaskaNative;
        public bool AmericanIndianAlaskaNative
        {
            get { return americanIndianAlaskaNative; }
            set { SetProperty(ref americanIndianAlaskaNative, value); }
        }

        bool asian;
        public bool Asian
        {
            get { return asian; }
            set { SetProperty(ref asian, value); }
        }

        bool blackAfricanAmerican;
        public bool BlackAfricanAmerican
        {
            get { return blackAfricanAmerican; }
            set { SetProperty(ref blackAfricanAmerican, value); }
        }

        bool nativeHawaiianOtherPacificIslander;
        public bool NativeHawaiianOtherPacificIslander
        {
            get { return nativeHawaiianOtherPacificIslander; }
            set { SetProperty(ref nativeHawaiianOtherPacificIslander, value); }
        }

        bool white;
        public bool White
        {
            get { return white; }
            set { SetProperty(ref white, value); }
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
                    await this.NavigationService.NavigateAsync("AddressPage", parameters, false);

                });
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ClientModel = parameters.GetValue<ClientModel>("clientModel");
            if (ClientModel != null)
            {
                this.EthnicityHispanicLatino = ClientModel.EthnicityHispanicLatino == 1;
                this.AmericanIndianAlaskaNative = ClientModel.AmericanIndianAlaskaNative == 1;
                this.Asian = ClientModel.Asian == 1;
                this.BlackAfricanAmerican = ClientModel.BlackAfricanAmerican == 1;
                this.NativeHawaiianOtherPacificIslander = ClientModel.NativeHawaiianOtherPacificIslander == 1;
                this.White = ClientModel.White == 1;
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
            ClientModel.EthnicityHispanicLatino = this.EthnicityHispanicLatino ? 1 :0;
            ClientModel.AmericanIndianAlaskaNative = this.AmericanIndianAlaskaNative ? 1 : 0;
            ClientModel.Asian = this.Asian ? 1 : 0;
            ClientModel.BlackAfricanAmerican = this.BlackAfricanAmerican ? 1 : 0;
            ClientModel.NativeHawaiianOtherPacificIslander = this.NativeHawaiianOtherPacificIslander ? 1 : 0;
            ClientModel.White = this.White ? 1 : 0;

        }


    }
}
