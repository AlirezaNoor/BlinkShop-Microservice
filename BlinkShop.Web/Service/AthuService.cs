using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using BlinkShop.Web.Utility;

namespace BlinkShop.Web.Service;

public class AthuService : IAthuService
{
    private readonly IBaseService _baseService;

    public AthuService(IBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<ResponseDto?> Login(LoginRequestDto loginRequestDto)
    {
        var url = SD.AthuUrlApi + "/Auth/Login";
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            url = url,
            Data = loginRequestDto
        });
    }

    public async Task<ResponseDto?> Regitertion(RegestrationRequestDto requestDto)
    {
        var url = SD.AthuUrlApi + "/Auth/Registeration";
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            url = url,
            Data = requestDto
        });
    }

    public  async Task<ResponseDto?> Addrole(RegestrationRequestDto requestDto)
    {
        var url = SD.AthuUrlApi + "/Auth/Addrole";
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            url = url,
            Data = requestDto
        });
    }
}