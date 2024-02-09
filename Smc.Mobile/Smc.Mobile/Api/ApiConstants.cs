using System;
using System.Collections.Generic;
using System.Text;

namespace Smc.Mobile.Api
{
    public class ApiConstants
    {

        public static readonly string Baseurl = "https://amde.dyteks.com/apipublic/";

        // public static readonly string AuthHeaderName = "Authorization";

        public const string ZipCode = @"zipcode?zip=";
        public const string GetTableInfo = @"GetTableInfo?internalId=";
        public const string RegisterTablet = @"RegisterTablet";
        public const string Sign = @"Sign?internalId=";
        public const string GetSignatureInfo = @"GetSignatureInfo?internalId=";


        public const string GetClient = @"GetClient?ssn=";
        public const string AddClient = @"AddClient";

    }
}
