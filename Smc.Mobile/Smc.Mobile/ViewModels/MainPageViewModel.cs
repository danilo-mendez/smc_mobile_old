using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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
        public MainPageViewModel(INavigationService navigationService, IBusyService busyService, IApiService apiService)
            : base(navigationService, busyService)
        {
            this.apiService = apiService;
            Title = "Bienvenido";

            LoadData();
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

                        if (result.ResponseCode != ResponseCodes.Success)
                        {
                            DisplayeAlert(result.Message);
                        }
                        else
                        {
                            if (result.Data.Id == 0)
                            {
                                var promptConfig = new PromptConfig
                                {
                                    InputType = InputType.Name,
                                    IsCancellable = false,
                                    Message = "Ingrese codigo tableta"
                                };

                                var dialogResult = await UserDialogs.Instance.PromptAsync(promptConfig);
                                if (dialogResult.Ok)
                                {
                                    if (!String.IsNullOrEmpty(dialogResult.Text))
                                    {
                                        var registerResult = await apiService.Register(dialogResult.Text);
                                        if (registerResult.ResponseCode == ResponseCodes.Success)
                                        {
                                            await UserDialogs.Instance.AlertAsync("Tableta Registrada exitosamente");
                                        }
                                        else
                                        {
                                            DisplayeAlert(registerResult.Message);
                                        }
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
                //return new DelegateCommand(() =>
                //{
                   

                //    //if (!LoginModel.CheckIsSavable())
                //    //    return;

                //    Device.BeginInvokeOnMainThread(async () =>
                //    {
                //        await this.NavigationService.NavigateAsync("/StartPage", null, false);
                //        //using (this.BusyService.BeginBusy())
                //        //{
                //        //    try
                //        //    {
                //        //        //await LoginModel.Login();
                //        //        //CrossSettings.Current.Set("UserId", LoginModel.UserId);
                //        //        //CrossSettings.Current.Set("Token", LoginModel.Token);
                //        //        //CrossSettings.Current.Set("HeightUnit", LoginModel.HeightUnit);
                //        //        //CrossSettings.Current.Set("WeightUnit", LoginModel.WeightUnit);
                //        //        //CrossSettings.Current.Set("Email", LoginModel.Email);
                //        //        //CrossSettings.Current.Set("UserId", LoginModel.UserId ?? Guid.Empty);

                             

                //        //    }
                //        //    catch (Exception ex)
                //        //    {
                //        //        HandleException(ex);
                //        //    }

                //        //}

                //    });
                //});
            }
        }

        public DelegateCommand GotoSignaturePadCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await this.NavigationService.NavigateAsync("/CreateClientNavigationPage/SignaturePadPage", null, false);
                });
     
            }
        }
    }
}
