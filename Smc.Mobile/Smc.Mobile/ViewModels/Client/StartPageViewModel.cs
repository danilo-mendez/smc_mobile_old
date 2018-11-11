using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smc.Mobile.ViewModels.Client
{
	public class StartPageViewModel : ViewModelBase
    {
        public StartPageViewModel(INavigationService navigationService)
       : base(navigationService)
        {
            Title = "Bienvenido";
             
        }

        public DelegateCommand SaveAndContinueCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await this.NavigationService.NavigateAsync("MainProfilePage", null, false);

                });
            }
        }
    }
}
