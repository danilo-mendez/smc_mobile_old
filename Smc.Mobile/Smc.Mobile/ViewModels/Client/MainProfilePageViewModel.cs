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
        }

        public List<String> GenderList
        {
            get; set;
        }
    }
}
