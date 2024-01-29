using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlinkShop.Services.ShopingCart.Model;

public class CratHeader
{
    [Key] public int id { get; set; }
    public string? userid { get; set; }

    public string? CouponCode { get; set; }
    [NotMapped] public double discount { get; set; }
    [NotMapped] public double cartTotal { get; set; }
}