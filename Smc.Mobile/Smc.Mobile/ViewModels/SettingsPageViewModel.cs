using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Smc.Mobile.Api;
using Smc.Mobile.Api.Dto;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels
{
	public class SettingsPageViewModel : ViewModelBase
    {
        private IProxyClientApi proxyClient;
        public SettingsPageViewModel(INavigationService navigationService, IBusyService busyService, IProxyClientApi proxyClient)
            : base(navigationService, busyService)
        {
            this.proxyClient = proxyClient;
            Title = "Bienvenido";

        }


    }
}
