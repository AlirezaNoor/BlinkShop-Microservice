namespace BlinkShop.Web.Utility;

public class SD
{
    public static string CouponBaseUrlApi { get; set; }
    public static string AthuUrlApi { get; set; }
    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}