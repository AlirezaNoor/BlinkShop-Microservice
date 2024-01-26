using BlicnkShop.Service.Athu.Api.model;
using BlicnkShop.Service.Athu.Api.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BlicnkShop.Service.Athu.Api.Controllers;

public class AuthController:BaseController
{
    private readonly IAthuServices _athuServices;
    private ResponseDto _responseDto;

    public AuthController(IAthuServices athuServices)
    {
        _athuServices = athuServices;
        _responseDto = new ResponseDto();
    }

    [HttpPost("Registeration")]
    public async Task<IActionResult> Register(RegestrationRequestDto regestrationRequestDto)
    {
        var user = await _athuServices.Regestration(regestrationRequestDto);
        if (!string.IsNullOrEmpty(user))
        {
            _responseDto.Success = false;
            _responseDto.Massege = user;
            return BadRequest(_responseDto);
        }
        else
        {
            return Ok(_responseDto);
        }
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody]LoginRequestDto  requestDto)
    {
        var user =await _athuServices.Login(requestDto);
        if (user==null)
        {
            _responseDto.Success = false;
            _responseDto.Massege = "this is massege";
            return BadRequest(_responseDto);
        }

        _responseDto.Result = user;
        return Ok(_responseDto);
    }
    
    [HttpPost("Addrole")]
    public async Task<IActionResult> Addrole(RegestrationRequestDto regestrationRequestDto)
    {
        var user = await _athuServices.AddRole(regestrationRequestDto.UserName,regestrationRequestDto.role);
        if (!user)
        {
            _responseDto.Success = false;
            _responseDto.Massege = "this is false";
            return BadRequest(_responseDto);
        }
        else
        {
            return Ok(_responseDto);
        }
    }
}