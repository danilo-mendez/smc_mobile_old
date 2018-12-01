using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

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

            YesNoOptionsList = new ObservableCollection<string>
            {
                "Si",
                "No",
                "Participante no se identifica"
            };

        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
        }
    
        public List<String> GenderList
        {
            get; set;
        }

        public ObservableCollection<String> YesNoOptionsList
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
