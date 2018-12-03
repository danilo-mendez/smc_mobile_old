using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Smc.Mobile.Api;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels
{
	public class CredentialsPageViewModel : ViewModelBase
    {
        private IApiService apiService;
        protected IPageDialogService pageDialogService;
        public CredentialsPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IApiService apiService)
            : base(navigationService, busyService)
        {
            this.apiService = apiService;
            this.pageDialogService = pageDialogService;

        }


        String password;
        public String Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public DelegateCommand ContinueCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (!String.IsNullOrEmpty(Password) && Password == "8521")
                    {
                        await this.NavigationService.NavigateAsync("SettingsPage", null, false);
                    }
                    else
                    {
                        await this.pageDialogService.DisplayAlertAsync("Alerta", "Password invalida", "OK");
                    }
                });
            }
        }
    }
}
