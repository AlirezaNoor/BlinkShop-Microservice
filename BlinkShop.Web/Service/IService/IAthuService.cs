using BlinkShop.Web.Models;

namespace BlinkShop.Web.Service.IService;

public interface IAthuService
{
    Task<ResponseDto?> Login(LoginRequestDto loginRequestDto);
    Task<ResponseDto?> Regitertion(RegestrationRequestDto requestDto);
    Task<ResponseDto?> Addrole(RegestrationRequestDto requestDto);
}