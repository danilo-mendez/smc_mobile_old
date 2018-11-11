using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smc.Mobile.ViewModels.Client
{
	public class AddressPageViewModel : ViewModelBase
    {
        public AddressPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Bienvenido";
        }

	}
}
