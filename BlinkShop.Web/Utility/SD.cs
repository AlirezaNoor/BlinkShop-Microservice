namespace BlinkShop.Web.Utility;

public class SD
{
    public static string CouponBaseUrlApi { get; set; }
    public static string AthuUrlApi { get; set; }
    public const string Admin = "ADMIN";
    public const string Costumer = "CUSTOMER";
    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}