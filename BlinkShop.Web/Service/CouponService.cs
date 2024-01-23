using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using BlinkShop.Web.Utility;

namespace BlinkShop.Web.Service;

public class CouponService : ICouponService
{
    private readonly IBaseService _baseService;

    public CouponService(IBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<ResponseDto?> GetAll()
    {
        var test = SD.CouponBaseUrlApi + "/CouponContorller";
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            url = SD.CouponBaseUrlApi + "/CouponContorller"
        });
    }

    public async Task<ResponseDto?> GetById(int id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            url = SD.CouponBaseUrlApi + "/CouponContorller/" + id
        });
    }

    public async Task<ResponseDto?> GetByCode(string code)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            url = SD.CouponBaseUrlApi + "/CouponContorller/" + code
        });
    }

    public async Task<ResponseDto?> Create(CouponDto couponDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            Data = couponDto,
            url = SD.CouponBaseUrlApi+"/CouponContorller"
        });
    }

    public async Task<ResponseDto?> Update(CouponDto couponDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.PUT,
            Data = couponDto,
            url = SD.CouponBaseUrlApi
        });
    }

    public async Task<ResponseDto?> Remove(int id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.DELETE,
            url = SD.CouponBaseUrlApi + "/CouponContorller/" + id
        });
    }
}