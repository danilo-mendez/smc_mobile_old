using Smc.Mobile.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.DeviceInfo;
using Acr.Settings;

namespace Smc.Mobile.Api
{
    public interface IApiService
    {
        Task<ServiceResponse<TabletInfoResponsetDto>> GetRegistrationInfo();

        Task<ServiceResponse<Boolean>> Register(String name);

    }

    public class ApiService : IApiService
    {
        private readonly IProxyClientApi proxyClient;

        public ApiService(IProxyClientApi proxyClient)
        {
            this.proxyClient = proxyClient;
        }

        public async Task<ServiceResponse<TabletInfoResponsetDto>> GetRegistrationInfo()
        {
            string id =  CrossDevice.Device.DeviceId;

            var result = await proxyClient.GetRequestAsync<TabletInfoResponsetDto>(ApiConstants.GetTableInfo + id);

            if (result.Ack == AckCode.Success && result.Data != null)
            {
                CrossSettings.Current.Set("Id", result.Data.Id);
                CrossSettings.Current.Set("TabletName", result.Data.Name);
                CrossSettings.Current.Set("InternalId", result.Data.InternalId);

                return await Task.FromResult(ServiceResponse<TabletInfoResponsetDto>.Success(result.Data));
            }
            else
            {
                return await Task.FromResult(ServiceResponse<TabletInfoResponsetDto>.Error(result != null ? result.Message : "Unmanaged exception"));
            }
        }

        public async Task<ServiceResponse<bool>> Register(string name)
        {
            string id = CrossDevice.Device.DeviceId;

            TabletInfoRequestDto tabletInfo = new TabletInfoRequestDto
            {
                TabletName = name,
                TabletInternalId = id
            };
            var result = await proxyClient.PostJsonRequestAsync<ResultResponseDto, TabletInfoRequestDto>(
                ApiConstants.RegisterTablet,
                tabletInfo);

            if (result.Ack == AckCode.Success)
            {
                CrossSettings.Current.Set("TabletName", name);
                CrossSettings.Current.Set("TabletId", id);

                return await Task.FromResult(ServiceResponse<Boolean>.Success(true));
            }
            else
            {
                return await Task.FromResult(ServiceResponse<Boolean>.Error(result != null ? result.Message : "Unmanaged exception"));
            }

         
        }
    }
}
