using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Smc.Mobile.Api
{
    public abstract class BaseClientApi : IProxyClientApi
    {
        protected HttpClient Client { set; get; }

        protected BaseClientApi(string baseUrl)
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        protected abstract void PrepareAuthorizeData();

        public abstract Task<ResponseEnvelope<TResponse>> DeleteJsonRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class;
        public abstract Task<ResponseEnvelope<TResponse>> GetRequestAsync<TResponse>(string url) where TResponse : class;
        public abstract Task<ResponseEnvelope<TResponse>> PostJsonRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class;
        public abstract Task<ResponseEnvelope<TResponse>> PostJsonRequestWithParamsAsync<TResponse>(string url, List<KeyValuePair<string, object>> param);
        public abstract Task<ResponseEnvelope<TResponse>> PutBytesRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class;
        public abstract Task<ResponseEnvelope<TResponse>> PutJsonRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class;

        public abstract Task<ResponseEnvelope<TResponse>> UploadBitmapAsync<TResponse>(string url, byte[] bitmapData, string parameterName);
    }
}
