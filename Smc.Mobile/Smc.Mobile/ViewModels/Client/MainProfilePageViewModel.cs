using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smc.Mobile.ViewModels.Client
{
	public class MainProfilePageViewModel : ViewModelBase
    {
        public MainProfilePageViewModel(INavigationService navigationService)
       : base(navigationService)
        {
            Title = "Bienvenido";

            GenderList = new List<string>();
            GenderList.AddRange(new string[] { "Femenino", "Masculino", "Participante no se identifica" });

            YesNoOptionsList = new List<string>();
            YesNoOptionsList.AddRange(new string[] { "No", "Si", "Participante no se identifica" });
        }

        public List<String> GenderList
        {
            get; set;
        }

        public List<String> YesNoOptionsList
        {
            get; set;
        }


        public DelegateCommand SaveAndContinueCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await this.NavigationService.NavigateAsync("DemographicPage", null, false);

                });
            }
        }
    }
}
