using Acr.Settings;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Smc.Mobile.Api;
using SMC.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IApiService apiService;
        protected IPageDialogService pageDialogService;

        public MainPageViewModel(INavigationService navigationService, IBusyService busyService, IPageDialogService pageDialogService, IApiService apiService)
            : base(navigationService, busyService)
        {
            this.apiService = apiService;
            this.pageDialogService = pageDialogService;

            Title = "Bienvenido SMC Mobile";

            LoadData();

            CrossSettings.Current.Changed += Current_Changed;

            UseForSignature = CrossSettings.Current.Get<bool>("UseForSignature", true);
            UseForRegister = CrossSettings.Current.Get<bool>("UseForRegister", true);
        }

        private void Current_Changed(object sender, SettingChangeEventArgs e)
        {
            switch (e.Key)
            {
                case "TabletName":

                    break;
                case "UseForSignature":
                    UseForSignature = CrossSettings.Current.Get<bool>("UseForSignature", true);
                    break;
                case "UseForRegister":
                    UseForRegister = CrossSettings.Current.Get<bool>("UseForRegister", true);

                    break;
            }
        }

        string tabletInfo;
        public string TabletInfo
        {
            get { return tabletInfo; }
            set { SetProperty(ref tabletInfo, value); }
        }

        private void LoadData()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                using (this.BusyService.BeginBusy())
                {
                    try
                    {
                        var result = await apiService.GetRegistrationInfo();

                        bool initialized = false;


                        if (result.ResponseCode != ResponseCodes.Success)
                        {
                            await this.pageDialogService.DisplayAlertAsync("Alerta", "La tableta no ha sido inicializada", "OK");
                        }
                        else
                        {
                            if (result.Data.Id > 0)
                            {
                                initialized = true;
                                TabletInfo = $"Tablet: {result.Data.Name}, id: {result.Data.InternalId}";
                            }
                        }

                        if (!initialized)
                        {
                            var promptConfig = new PromptConfig
                            {
                                InputType = InputType.Name,
                                IsCancellable = false,
                                Message = "Ingrese codigo tableta"
                            };

                            //var action = await pageDialogService.DisplayActionSheetAsync("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");

                            var dialogResult = await UserDialogs.Instance.PromptAsync(promptConfig);
                            if (dialogResult.Ok)
                            {
                                if (!String.IsNullOrEmpty(dialogResult.Text))
                                {
                                    var registerResult = await apiService.Register(dialogResult.Text);
                                    if (registerResult.ResponseCode == ResponseCodes.Success)
                                    {

                                        await this.pageDialogService.DisplayAlertAsync("Alerta", "Tableta Registrada exitosamente", "OK");
                                    }
                                    else
                                    {
                                        await this.pageDialogService.DisplayAlertAsync("Error", registerResult.Message, "OK");
                                    }
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }

                }

            });
        }


        public DelegateCommand GotoRegisterClientCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    //Navegacion absolute
                    //Para navegacion no absoluta  NavigationPage/StartPage
                    await this.NavigationService.NavigateAsync("/CreateClientNavigationPage/WelcomePage", null, false);

                });
            }
        }

        public DelegateCommand GotoSignaturePadCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        var response = await this.apiService.GetPendingSignatureInfo();
                        if (response.Data != null && response.Data.Id > 0)
                        {
                            await this.NavigationService.NavigateAsync("SignaturePadPage", null, false);
                        }
                        else
                        {
                            await this.pageDialogService.DisplayAlertAsync("Alerta", "No existe reporte pendiente para esta tablet", "OK");
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }

                });

            }
        }

        public DelegateCommand SettingCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    NavigationService.PushPopupAsync()
                    //var promptConfig = new PromptConfig
                    //{
                    //    InputType = InputType.NumericPassword,
                    //    IsCancellable = false,
                    //    Message = "Ingrese clave"
                    //};

                    //var dialogResult = await UserDialogs.Instance.PromptAsync(promptConfig);
                    //if (dialogResult.Ok)
                    //{
                    //    if (!String.IsNullOrEmpty(dialogResult.Text) && dialogResult.Text == "8521")
                    //    {
                    //        await this.NavigationService.NavigateAsync("SettingsPage", null, false);
                    //    }
                    //    else
                    //    {
                    //        await this.pageDialogService.DisplayAlertAsync("Alerta", "Clave Invalida", "OK");
                    //    }

                    //}
                    await this.NavigationService.NavigateAsync("CredentialsPage", null, false);


                });
            }
        }

        bool useForSignature;
        public bool UseForSignature
        {
            get { return useForSignature; }
            set { SetProperty(ref useForSignature, value); }
        }
        bool useForRegister;
        public bool UseForRegister
        {
            get { return useForRegister; }
            set { SetProperty(ref useForRegister, value); }
        }

    }
}
