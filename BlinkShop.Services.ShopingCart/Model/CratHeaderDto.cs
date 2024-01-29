namespace BlinkShop.Services.ShopingCart.Model;

public class CratHeaderDto
{
    public int id { get; set; }
    public string userid { get; set; }
    public string? CouponCode { get; set; }
    public double discount { get; set; }
    public double cartTotal { get; set; }
}