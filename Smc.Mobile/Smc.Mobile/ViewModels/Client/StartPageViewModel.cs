using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels.Client
{
	public class StartPageViewModel : ViewModelBase
    {
        public StartPageViewModel(INavigationService navigationService, IBusyService busyService)
       : base(navigationService, busyService)
        {
            Title = "Bienvenido";
             
        }
 

        public DelegateCommand SaveAndContinueCommand
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
                                await this.NavigationService.NavigateAsync("MainProfilePage", null, false);
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
