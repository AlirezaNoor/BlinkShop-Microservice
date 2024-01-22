using BlinkShop.Web.Models;

namespace BlinkShop.Web.Service.IService;

public interface ICouponService
{
    Task<ResponseDto?> GetAll();
    Task<ResponseDto?> GetById(int id);
    Task<ResponseDto?> GetByCode(string code);
    Task<ResponseDto?> Create(CouponDto couponDto);
    Task<ResponseDto?> Update(CouponDto couponDto);
    Task<ResponseDto?> Remove(int id);
}