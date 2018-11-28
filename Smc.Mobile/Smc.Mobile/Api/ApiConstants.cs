using System;
using System.Collections.Generic;
using System.Text;

namespace Smc.Mobile.Api
{
    public class ApiConstants
    {
        //public static readonly string Baseurl = "http://192.168.1.26/apipublic/";
        public static readonly string Baseurl = "https://smc.dyteks.com/apipublic/";
        // public static readonly string AuthHeaderName = "Authorization";

        public const string ZipCode = @"zipcode?zip=";
        public const string GetTableInfo = @"GetTableInfo?internalId=";
        public const string RegisterTablet = @"RegisterTablet";
        public const string Sign = @"Sign?internalId=";
        public const string GetSignatureInfo = @"GetSignatureInfo?internalId=";

    }
}
