using Prism;
using Prism.Ioc;
using Smc.Mobile.ViewModels;
using Smc.Mobile.ViewModels.Client;
using Smc.Mobile.Views;
using Smc.Mobile.Views.Client;
using SMC.Mobile.Infrastructure;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Smc.Mobile
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
             Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA3MjNAMzEzNjJlMzIyZTMwTXIvTkp0MlB4MjAwWnhrZ0gzTVJ4L1E3TFRrYXlObEZjTm9najMrNzJMbz0=");
            //  Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDE3NDBAMzEzNjJlMzMyZTMwVlRMZnB4U3lnQWowTWQrR1NTZFlvVW9sTlBwRHFYR3hDaUhzZTIrVXl1OD0=");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CreateClientNavigationPage>();

            containerRegistry.Register<IBusyService, BusyService>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<StartPage, StartPageViewModel>();
            containerRegistry.RegisterForNavigation<MainProfilePage, MainProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<DemographicPage, DemographicPageViewModel>();
        }
    }
}
