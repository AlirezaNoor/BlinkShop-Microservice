using BlinkShop.Web.Models;

namespace BlinkShop.Web.Service.IService;

public interface IBaseService
{
    Task<ResponseDto?> SendAsync(RequestDto requestDto,bool jwt=true);
}