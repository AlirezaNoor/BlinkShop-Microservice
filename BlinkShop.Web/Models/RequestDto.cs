using BlinkShop.Web.Utility;

namespace BlinkShop.Web.Models;

public class RequestDto
{
    public SD.ApiType ApiType { get; set; } = SD.ApiType.GET;
    public string url { get; set; }
    public object Data { get; set; }
    public string AccessToken { get; set; }
}