using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Smc.Mobile.Api;
using Smc.Mobile.Api.Dto;
using Smc.Mobile.Model;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels.Client
{
    public abstract class BaseClientViewModel : ViewModelBase
    {
        protected IProxyClientApi proxyClient;
        protected IPageDialogService pageDialogService;


        public  BaseClientViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IProxyClientApi proxyClient)
            : base(navigationService, busyService)
        {
            this.proxyClient = proxyClient;
            this.pageDialogService = pageDialogService;

            InitLookups();
        }

        private void InitLookups()
        {

            GenderList = new List<IdNameModel>
            {
                new IdNameModel { Id = 2, Name = "Femenino" },
                new IdNameModel { Id = 1, Name = "Masculino" },
                new IdNameModel { Id = 9, Name = "No sabe, o no contesta" }
            };

            YesNoOptionsList = new List<IdNameModel>
            {
                new IdNameModel { Id = 1, Name = "Si" },
                new IdNameModel { Id = 0, Name = "No" },
            };

            YesNoNotIdentifyList = new List<IdNameModel>
            {
                new IdNameModel { Id = 1, Name = "Si" },
                new IdNameModel { Id = 0, Name = "No" },
                new IdNameModel { Id = 9, Name = "No sabe, o no contesta" }
            };

            PhoneTypeList = new List<IdNameModel>
            {
                new IdNameModel { Id = 1, Name = "Casa" },
                new IdNameModel { Id = 2, Name = "Celular" },
                new IdNameModel { Id = 3, Name = "Trabajo" },
                new IdNameModel { Id = 4, Name = "Otro" }
            };

            LicenseCategoryList = new List<IdNameModel>
            {
                new IdNameModel { Id = 1, Name = "Aprendizaje" },
                new IdNameModel { Id = 2, Name = "Conductor" },
                new IdNameModel { Id = 3, Name = "Chofer" },
                new IdNameModel { Id = 4, Name = "Vehiculo Pesado Tipo 1 (Cat 6)" },
                new IdNameModel { Id = 5, Name = "Vehiculo Pesado Tipo 2 (Cat 7)" },
                new IdNameModel { Id = 6, Name = "Vehiculo Pesado Tipo 3 (Cat 8)" },
                new IdNameModel { Id = 7, Name = "Tractor o Remolcador (Cat 9)" },
                new IdNameModel { Id = 8, Name = "Motocicleta" }
            };


            HighestEducationalLevelCompletedList = new List<IdNameModel>
            {
                new IdNameModel { Id = 0, Name = "No Educational Level Completed" },
                new IdNameModel { Id = 1, Name = "Attained secondary school diploma" },
                new IdNameModel { Id = 2, Name = "Attained a secondary school equivalency" },
                new IdNameModel { Id = 3, Name = "The participant with a disability receives a certificate of attendance/completion as a result of successfully completing an Individualized Education Program (IEP)" },
                new IdNameModel { Id = 4, Name = "Completed one of more years of postsecondary education" },
                new IdNameModel { Id = 5, Name = "Attained a postsecondary technical or vocational certificate (non-degree)" },
                new IdNameModel { Id = 6, Name = "Attained an Associate degree" },
                new IdNameModel { Id = 7, Name = "Attained a Bachelor degree" },
                new IdNameModel { Id = 8, Name = "Attained a degree beyond a Bachelor degree" }
            };

            VisitPurposeList = new List<IdNameModel>
            {
                  new IdNameModel { Id = 1 , Name = "Ayuda con certificaciones de gobierno" },
                  new IdNameModel { Id = 2 , Name = "Búsqueda de empleo" },
                  new IdNameModel { Id = 3 , Name = "Cita con consejero o manejador de casos" },
                  new IdNameModel { Id = 4 , Name = "Cita con representante (Socio CGU)" },
                  new IdNameModel { Id = 5 , Name = "Cita con técnico de servicios" },
                  new IdNameModel { Id = 6 , Name = "Entrevista inicial" },
                  new IdNameModel { Id = 7 , Name = "Nombramiento o registro a servicio" },
                  new IdNameModel { Id = 8 , Name = "Orientación inicial sobre los programas - WIOA" },
                  new IdNameModel { Id = 9 , Name = "Orientación sobre los servicios del CGU y Socios" },
                  new IdNameModel { Id = 10, Name = "Orientación sobre adiestramientos" },
                  new IdNameModel { Id = 11, Name = "Pruebas de alfabetización" },
                  new IdNameModel { Id = 12, Name = "Redacción de resumes" },
                  new IdNameModel { Id = 13, Name = "Referidos de otras agencias fuera del CGU" },
                  new IdNameModel { Id = 14, Name = "Traer documentación " },
                  new IdNameModel { Id = 15, Name = "Uso del CGU - Auto-Gestión" },
                  new IdNameModel { Id = 16, Name = "Otro Propósito" },
            };
        }

        public List<IdNameModel> GenderList
        {
            get; set;
        }

        public List<IdNameModel> YesNoOptionsList
        {
            get; set;
        }


        public List<IdNameModel> YesNoNotIdentifyList
        {
            get; set;
        }

        public List<IdNameModel> PhoneTypeList
        {
            get; set;
        }

        public List<IdNameModel> LicenseCategoryList
        {
            get; set;
        }
        public List<IdNameModel> HighestEducationalLevelCompletedList
        {
            get; set;
        }

        public List<IdNameModel> VisitPurposeList
        {
            get; set;
        }

        protected ClientModel ClientModel
        {
            get;set;
        }

     
    }
}
