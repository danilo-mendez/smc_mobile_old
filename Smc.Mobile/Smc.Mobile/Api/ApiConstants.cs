using System;
using System.Collections.Generic;
using System.Text;

namespace Smc.Mobile.Api
{
    public class ApiConstants
    {
        public static readonly string Baseurl = "http://smc.dyteks.com/apipublic";
        public static readonly string AuthHeaderName = "Authorization";

        public const string ZipCode = @"/zipcode?zip=";
        //public const string ForgotPassword = @"forgot-password";
        //public const string ForgotPasswordValidateCode = @"forgot-password-validate-code";
        //public const string ForgotPasswordResetPassword = @"forgot-password-reset-password";
        //public const string ExitsEmail = @"exists-email";
        //public const string Logout = @"logout";
        //public const string SignUp = @"signup";
        //public const string UpdateProfile = @"update-profile";
        //public const string ValidateCodeForForgotPassword = @"forgot-password/validate-code";
        //public const string GetAuthStaus = @"auth-status";

        //public const string InstantMood = @"instant-mood";

        //public const string GetPersonal = @"personal";
        //public const string PersonalFullName = @"personal/full-name";


        public static string GetUrl(string endpoint)
        {
            return string.Format("wp-json/nd/v1/{0}", endpoint);
        }
    }
}
