using Ecom.Shared.CommonService.Dtos;
using Ecom.Web.Interfaces;
using Ecom.Web.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Ecom.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDto> SendRequestAsync(RequestDto requestDto)
        {
            var client = _httpClient.CreateClient("EcomCouponServiceAPI");
            HttpRequestMessage message = new();
            
            //token
            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(requestDto.Url);
            switch (requestDto.APIType)
            {
                case APIMethod.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case APIMethod.GET:
                    message.Method = HttpMethod.Get;
                    break;
                case APIMethod.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case APIMethod.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
            }
            HttpResponseMessage? apiResponse = await client.SendAsync(message);
            var stringAPIResponse = await apiResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseDto>(stringAPIResponse);
        }
    }
}
