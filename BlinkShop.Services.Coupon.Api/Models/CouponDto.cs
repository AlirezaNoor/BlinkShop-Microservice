﻿namespace BlinkShop.Services.Coupon.Api.Models;

public class CouponDto
{
    public int CouponId { get; set; }
    public string CouponCode { get; set; }
    public  double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}