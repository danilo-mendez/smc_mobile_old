using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Smc.Mobile.Api
{
    public class WebClientApi : BaseClientApi
    {
        public WebClientApi(string baseUrl) : base(baseUrl)
        {
        }

        protected override void PrepareAuthorizeData()
        {
            //var userRepository = (App.Current as Prism.DryIoc.PrismApplication).Container.Resolve<IUserRepository>();
            //var currentUser = userRepository.GetUser();

            ////if (currentUser != null)
            ////{
            ////    var authorizationHeader =string.Format("Bearer {0}",currentUser.AuthCode);
            ////    if (Client.DefaultRequestHeaders.Contains(ApiUrlProvider.AuthHeaderName))
            ////    {
            ////        Client.DefaultRequestHeaders.Remove(ApiUrlProvider.AuthHeaderName);
            ////    }
            ////    Client.DefaultRequestHeaders.Add(ApiUrlProvider.AuthHeaderName, authorizationHeader);
            ////}
        }

        private string ToBase64(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        private async Task<ResponseEnvelope<TResponse>> HandleResponseAsync<TResponse>(HttpResponseMessage response)
        {
            string result;
            using (var content = response.Content)
            {
                result = await content.ReadAsStringAsync();
            }

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ApiException(result, response.StatusCode);
            }
            else
            {
                var obj = JsonConvert.DeserializeObject<ResponseEnvelope<TResponse>>(result);

                return await Task.FromResult(obj);

              //  return await ResponseEnvelope<TResponse>.SuccessAsync(JsonConvert.DeserializeObject<TResponse>(result));
            }


        }

        public override async Task<ResponseEnvelope<TResponse>> PostJsonRequestWithParamsAsync<TResponse>(string url, List<KeyValuePair<string, object>> param)
        {
            PrepareAuthorizeData();

            var serializedParams = new List<KeyValuePair<string, string>>();
            foreach (var p in param)
            {
                serializedParams.Add(new KeyValuePair<string, string>(p.Key, JsonConvert.SerializeObject(p.Value)));
            }
            var serializedData = new FormUrlEncodedContent(serializedParams);


            var message = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = serializedData
            };
            using (var response = await Client.SendAsync(message))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }

        public override async Task<ResponseEnvelope<TResponse>> GetRequestAsync<TResponse>(string url)
        {

            //authorize
            PrepareAuthorizeData();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = await Client.GetAsync(url))
            {
                return await HandleResponseAsync<TResponse>(response);
            }

        }

        public override async Task<ResponseEnvelope<TResponse>> PostJsonRequestAsync<TResponse, TRequest>(string url, TRequest request)
        {
            PrepareAuthorizeData();

            StringContent content;
            if (request != null)
            {
                var serializedData = JsonConvert.SerializeObject(request);
                //authorize
                content = new StringContent(serializedData);
            }
            else
            {
                content = new StringContent(string.Empty);
            }
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            using (var response = await Client.PostAsync(url, content))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }

        public override async Task<ResponseEnvelope<TResponse>> DeleteJsonRequestAsync<TResponse, TRequest>(string url, TRequest request)
        {
            PrepareAuthorizeData();

            StringContent content;
            if (request != null)
            {
                var serializedData = JsonConvert.SerializeObject(request);
                //authorize
                content = new StringContent(serializedData);
            }
            else
            {
                content = new StringContent(string.Empty);
            }
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            using (var response = await Client.DeleteAsJsonAsync<TRequest>(url, request))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }


        public override async Task<ResponseEnvelope<TResponse>> PutJsonRequestAsync<TResponse, TRequest>(string url, TRequest request)
        {
            PrepareAuthorizeData();


            StringContent content;
            if (request != null)
            {
                var serializedData = JsonConvert.SerializeObject(request);
                //authorize
                content = new StringContent(serializedData);
            }
            else
            {
                content = new StringContent(string.Empty);
            }
            //authorize
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            using (var response = await Client.PutAsync(url, content))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }

        public override async Task<ResponseEnvelope<TResponse>> PutBytesRequestAsync<TResponse, TRequest>(string url, TRequest request)
        {
            PrepareAuthorizeData();


            StringContent content;
            if (request != null)
            {
                var serializedData = JsonConvert.SerializeObject(request);
                //authorize
                content = new StringContent(serializedData);
            }
            else
            {
                content = new StringContent(string.Empty);
            }
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            using (var response = await Client.PostAsync(url, content))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }

        public override async Task<ResponseEnvelope<TResponse>> UploadBitmapAsync<TResponse>(string url, byte[] bitmapData, string parameterName)
        {
            PrepareAuthorizeData();

            var fileContent = new ByteArrayContent(bitmapData);

            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = parameterName,
                FileName = "my_uploaded_image.png"
            };

            MultipartFormDataContent multipartContent = new MultipartFormDataContent();
            multipartContent.Add(fileContent);

            HttpClient httpClient = new HttpClient();
            using (var response = await Client.PostAsync(url, multipartContent))
            {
                return await HandleResponseAsync<TResponse>(response);
            }
        }
    }
}
