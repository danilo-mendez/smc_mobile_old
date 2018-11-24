using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smc.Mobile.Api
{
    public interface IProxyClientApi
    {
        Task<ResponseEnvelope<TResponse>> DeleteJsonRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class;
        Task<ResponseEnvelope<TResponse>> GetRequestAsync<TResponse>(string url) where TResponse : class;
        Task<ResponseEnvelope<TResponse>> PostJsonRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class;
        Task<ResponseEnvelope<TResponse>> PostJsonRequestWithParamsAsync<TResponse>(string url, List<KeyValuePair<string, object>> param);
        Task<ResponseEnvelope<TResponse>> PutBytesRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class;
        Task<ResponseEnvelope<TResponse>> PutJsonRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class;

        Task<ResponseEnvelope<TResponse>> UploadBitmapAsync<TResponse>(string url, byte[] bitmapData, string parameterName);
    }
}
