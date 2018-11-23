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

            LicenseCategoryList = new List<string>();
            LicenseCategoryList.AddRange(new string[] { "Aprendizaje", "Conductor", "Chofer" });
            LicenseCategoryList.AddRange(new string[] { "Vehiculo Pesado Tipo 1 (Cat 6)", "Vehiculo Pesado Tipo 2 (Cat 7)", "Vehiculo Pesado Tipo 3 (Cat 8)" });
            LicenseCategoryList.AddRange(new string[] { "Tractor o Remolcador (Cat 9)", "Motocicleta" });

            HighestEducationalLevelCompletedList = new List<string>();
            HighestEducationalLevelCompletedList.AddRange(new string[] { "No Educational Level Completed", "Attained secondary school diploma", "Attained a secondary school equivalency" });
            HighestEducationalLevelCompletedList.AddRange(new string[] { "The participant with a disability receives a certificate of attendance/completion as a result of successfully completing an Individualized Education Program (IEP)" });
            HighestEducationalLevelCompletedList.AddRange(new string[] { "Completed one of more years of postsecondary education", "Attained a postsecondary technical or vocational certificate (non-degree)" });
            HighestEducationalLevelCompletedList.AddRange(new string[] { "Attained an Associate degree", "Attained a Bachelor degree", "Attained a degree beyond a Bachelor degree" });

        }


        public List<String> PhoneTypeList
        {
            get; set;
        }

        public List<String> LicenseCategoryList
        {
            get; set;
        }
        public List<String> HighestEducationalLevelCompletedList
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
