using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Smc.Mobile.ViewModels.Client
{
	public class ContactInfoPageViewModel : ViewModelBase
    {
        public ContactInfoPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Bienvenido";

            PhoneTypeList = new List<string>();
            PhoneTypeList.AddRange(new string[] { "Casa", "Celular", "Trabajo", "Otro" });
        }


        public List<String> PhoneTypeList
        {
            get; set;
        }

        public DelegateCommand SaveAndContinueCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await this.NavigationService.NavigateAsync("ContactInfoPage", null, false);

                });
            }
        }
    }
}
