using Microsoft.AspNetCore.Mvc;

namespace BlicnkShop.Service.Athu.Api.Controllers;

public class AuthController:BaseController
{
    [HttpPost("Registeration")]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }
}