using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;

namespace BlinkShop.Web.Service;

public class CouponService:ICouponService
{
    private readonly IBaseService _baseService;

    public CouponService(IBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<ResponseDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto?> GetByCode(string code)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto?> Create(CouponDto couponDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto?> Update(CouponDto couponDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto?> Remove(int id)
    {
        throw new NotImplementedException();
    }
}