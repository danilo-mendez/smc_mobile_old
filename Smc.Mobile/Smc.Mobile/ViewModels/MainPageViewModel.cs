using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Smc.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
        }


        public DelegateCommand GotoRegisterClientCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    //Navegacion absolute
                    //Para navegacion no absoluta  NavigationPage/StartPage
                    await this.NavigationService.NavigateAsync("/NavigationPage/StartPage", null, false);

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
    }
}
