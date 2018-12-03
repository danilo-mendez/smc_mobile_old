using Acr.Settings;
using Acr.UserDialogs;
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
    }
}
