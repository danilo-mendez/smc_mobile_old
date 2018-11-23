using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smc.Mobile.Api
{
    public enum AckCode
    {
        Success, Error, Failure, Notfound, Unauthorized
    }

    public class ResponseEnvelope<T>
    {
        public T Data { get; set; }

        public AckCode Ack { get; set; }

        public String Message { get; set; }

        public Exception Exception { get; set; }

        public static ResponseEnvelope<T> Success(T data)
        {
            var response = new ResponseEnvelope<T>
            {
                Ack = AckCode.Success,
                Data = data
            };
            return response;
        }

        public static async Task<ResponseEnvelope<T>> SuccessAsync(T data)
        {
            return await Task.FromResult(Success(data));

        }


    }

    public class ResponseEnvelope
    {

        public AckCode Ack { get; set; }

        public String Message { get; set; }

        public Exception Exception { get; set; }

        public static ResponseEnvelope Success()
        {
            var response = new ResponseEnvelope
            {
                Ack = AckCode.Success,
            };
            return response;
        }

        public static async Task<ResponseEnvelope> SuccessAsync()
        {
            return await Task.FromResult(Success());

        }

        public static ResponseEnvelope Error(String message, Exception ex = null)
        {
            var response = new ResponseEnvelope
            {
                Ack = AckCode.Error,
                Message = message,
                Exception = ex
            };
            return response;
        }

        public static async Task<ResponseEnvelope> ErrorAsync(String message, Exception ex = null)
        {
            return await Task.FromResult(Error(message, ex));

        }

        public static ResponseEnvelope Error(Exception exception)
        {
            var response = new ResponseEnvelope
            {
                Ack = AckCode.Error,
                Message = exception.Message
            };
            return response;
        }




    }
}
