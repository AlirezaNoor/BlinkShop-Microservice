using BlicnkShop.Service.Athu.Api.model;

namespace BlicnkShop.Service.Athu.Api.Service.IService;

public interface IAthuServices
{
    Task<string> Regestration(RegestrationRequestDto regestrationRequestDto);
    Task<LoginResponeseDto> Login(LoginRequestDto loginRequestDto);
    Task<bool> AddRole(string UserName, string roleName);
}