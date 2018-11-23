using System;
using System.Collections.Generic;
using System.Text;

namespace Smc.Mobile.Api
{
    public class ApiException : Exception
    {


        public ApiException(string message)
            : base(message)
        {

        }

        public ApiException(string message, System.Net.HttpStatusCode statusCode)
            : base(message)
        {
            this.HttpStatusCode = statusCode;
            switch (statusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:

                    break;
                    //case System.Net.HttpStatusCode.BadRequest:
                    //    {
                    //        var dataResponse = JsonConvert.DeserializeObject<BaseResponseMessage>(message);
                    //    }
                    //case System.Net.HttpStatusCode.Unauthorized:
                    //    //var dataResponse = JsonConvert.DeserializeObject<BaseResponseMessage>(result);
                    //    MessagingWrapper.Instance.SendMessage(MessagingWrapper.Messages.UnAuthorizedRequest);
                    //    return await ResponseEnvelope<TResponse>.UnAuthorizedAsync(string.Empty);
                    //case System.Net.HttpStatusCode.InternalServerError:
                    //    {
                    //       var dataResponse = JsonConvert.DeserializeObject<BaseResponseMessage>(result);
                    //        return await ResponseEnvelope<TResponse>.ErrorAsync(dataResponse.Message);
                    //    }
                    //case System.Net.HttpStatusCode.NotFound:
                    //    {
                    //        var dataResponse = JsonConvert.DeserializeObject<BaseResponseMessage>(result);
                    //        return await ResponseEnvelope<TResponse>.NotFoundAsync(dataResponse.Message);
                    //    }
            }

        }

        public System.Net.HttpStatusCode HttpStatusCode
        {
            get;
        }
    }
}
