using BlinkShop.Web.Service.IService;
using BlinkShop.Web.Utility;

namespace BlinkShop.Web.Service;

public class TokenProvider:ITokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TokenProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetToken()
    {
        string? Token = null;
        var result=_httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(SD.TokenProvider, out Token);

        return result ? Token : null;
    }

    public void ClearToken()
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Delete(SD.TokenProvider);
    }

    public void SetToken(string token)
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Append(SD.TokenProvider,token);
     }
}