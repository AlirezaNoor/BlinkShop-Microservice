using System.Net;
using System.Text;
using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using BlinkShop.Web.Utility;
using Newtonsoft.Json;

namespace BlinkShop.Web.Service;

public class BaseService:IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITokenProvider _tokenProvider;
    public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
    {
        _httpClientFactory = httpClientFactory;
        _tokenProvider = tokenProvider;
    }

    public async Task<ResponseDto?> SendAsync(RequestDto requestDto,bool jwt=true)
    {
        try
        {
            
            HttpClient client = _httpClientFactory.CreateClient("BlinkShopApi");
            HttpRequestMessage massege = new();
            massege.Headers.Add("Accept", "application/json");

            if (jwt == true)
            {
               var token= _tokenProvider.GetToken();
               massege.Headers.Add("Authorization",$"Bearer {token}");
            }
            //token
            massege.RequestUri = new Uri(requestDto.url);
            if (requestDto.Data != null)
            {
                massege.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8,
                    "application/json");
            }

            switch (requestDto.ApiType)
            {
                case SD.ApiType.POST:
                    massege.Method = HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    massege.Method = HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    massege.Method = HttpMethod.Delete;
                    break;
                default:
                    massege.Method = HttpMethod.Get;
                    break;
            }

            HttpResponseMessage? response = null;

            response = await client.SendAsync(massege);

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new ResponseDto() { Success = false, Result = null, Massege = "Notfound" };
                    break;
                case HttpStatusCode.Unauthorized:
                    return new ResponseDto() { Success = false, Result = null, Massege = "Notfound" };
                    break;
                case HttpStatusCode.Forbidden:
                    return new ResponseDto() { Success = false, Result = null, Massege = "Notfound" };
                    break;
                case HttpStatusCode.InternalServerError:
                    return new ResponseDto() { Success = false, Result = null, Massege = "Notfound" };
                    break;
                default:
                    var apiContact = await response.Content.ReadAsStringAsync();
                    var Responsemethod = JsonConvert.DeserializeObject<ResponseDto>(apiContact);
                    return Responsemethod;

            }

        }
        catch (Exception e)
        {
            return new ResponseDto()
            {
                Success = false,
                Massege = e.Message.ToString()
            };
        }
    }
}