using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smc.Mobile.Api
{
    public enum ResponseCodes
    {
        Success, Error
    }

    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public ResponseCodes ResponseCode { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public static ServiceResponse<T> Success(T data)
        {
            var response = new ServiceResponse<T>
            {
                ResponseCode = ResponseCodes.Success,
                Data = data
            };
            return response;
        }

        public static async Task<ServiceResponse<T>> SuccessAsync(T data)
        {
            return await Task.FromResult(Success(data));

        }

        public static ServiceResponse<T> Error(string message, Exception ex = null)
        {
            var response = new ServiceResponse<T>
            {
                ResponseCode = ResponseCodes.Error,
                Message = message,
                Exception = ex
            };
            return response;
        }

        public static async Task<ServiceResponse<T>> ErrorAsync(string message, Exception ex = null)
        {
            return await Task.FromResult(Error(message, ex));

        }
    }
}
