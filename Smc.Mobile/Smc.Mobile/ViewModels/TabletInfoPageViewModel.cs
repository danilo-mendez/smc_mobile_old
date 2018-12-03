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
	public class TabletInfoPageViewModel : ViewModelBase
    {
        private IApiService apiService;
        protected IPageDialogService pageDialogService;
        public TabletInfoPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IApiService apiService)
            : base(navigationService, busyService)
        {
            this.apiService = apiService;
            this.pageDialogService = pageDialogService;

        }


        String name;
        public String Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public DelegateCommand ContinueCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (!String.IsNullOrEmpty(Name))
                    {
                        var registerResult = await apiService.Register(Name);
                        if (registerResult.ResponseCode == ResponseCodes.Success)
                        {

                            await this.pageDialogService.DisplayAlertAsync("Alerta", "Tableta Registrada exitosamente", "OK");


                            await this.NavigationService.NavigateAsync("/CreateClientNavigationPage/MainPage", null, false);

                        }
                        else
                        {
                            await this.pageDialogService.DisplayAlertAsync("Error", registerResult.Message, "OK");
                        }

                    }
                    else
                    {
                        await this.pageDialogService.DisplayAlertAsync("Alerta", "Nombre invalido", "OK");
                    }
                });
            }
        }
    }
}
