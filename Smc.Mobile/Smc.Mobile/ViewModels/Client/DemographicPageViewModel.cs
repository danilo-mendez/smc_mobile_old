using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smc.Mobile.ViewModels.Client
{
	public class DemographicPageViewModel : ViewModelBase
    {
        public DemographicPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Bienvenido";

            YesNoOptionsList = new List<string>();
            YesNoOptionsList.AddRange(new string[] { "No", "Si", "Participante no se identifica" });
        }

    
        public List<String> YesNoOptionsList
        {
            get; set;
        }
    }
}
