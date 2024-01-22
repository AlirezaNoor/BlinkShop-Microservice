using AutoMapper;
using BlinkShop.Services.Coupon.Api.Models;

namespace BlinkShop.Services.Coupon.Api.config;

public class MappingConfig
{
    public static MapperConfiguration RegesterMap()
    {
        var mappongConfig = new MapperConfiguration(cofig =>
        {
            cofig.CreateMap<Models.Coupon,CouponDto>();
            cofig.CreateMap<CouponDto,Models.Coupon>();
        });
        return mappongConfig;
    }
}