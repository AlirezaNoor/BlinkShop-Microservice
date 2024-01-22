using System.ComponentModel.DataAnnotations;

namespace BlinkShop.Services.Coupon.Api.Models;

public class Coupon
{
    [Key]
    public int CouponId { get; set; }
    public string CouponCode { get; set; }
    public  double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
    public DateTime LastUpdated { get; set; }=DateTime.Now;
}