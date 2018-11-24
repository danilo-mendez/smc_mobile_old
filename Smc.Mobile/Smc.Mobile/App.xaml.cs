using Prism;
using Prism.Ioc;
using Smc.Mobile.Api;
using Smc.Mobile.ViewModels;
using Smc.Mobile.ViewModels.Client;
using Smc.Mobile.Views;
using Smc.Mobile.Views.Client;
using Smc.Mobile.Views.Signature;
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

            //https://www.syncfusion.com/account/downloads
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA3MjNAMzEzNjJlMzIyZTMwTXIvTkp0MlB4MjAwWnhrZ0gzTVJ4L1E3TFRrYXlObEZjTm9najMrNzJMbz0=");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDI1MThAMzEzNjJlMzMyZTMwUDEyZ1Q5WTdmT3ZldFM4NlArS1RQRW9PUWlBcWZsTHNkbE1EeXprQm14VT0=");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CreateClientNavigationPage>();
            

            containerRegistry.Register<IBusyService, BusyService>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterInstance<IProxyClientApi>(new WebClientApi(ApiConstants.Baseurl));

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<StartPage, StartPageViewModel>();
            containerRegistry.RegisterForNavigation<MainProfilePage, MainProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<DemographicPage, DemographicPageViewModel>();
            containerRegistry.RegisterForNavigation<AddressPage, AddressPageViewModel>();
            containerRegistry.RegisterForNavigation<ContactInfoPage, ContactInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<SignaturePadPage, SignaturePadPageViewModel>();
        }
    }
}
