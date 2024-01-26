using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BlinkShop.Web.Controllers;

public class AthuController:Controller
{
    private readonly IAthuService _athuService;

    public AthuController(IAthuService athuService)
    {
        _athuService = athuService;
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        LoginRequestDto login = new LoginRequestDto();
        return View(login);

    }
    [HttpGet]
    public async Task<IActionResult> Regestration()
    {
      
        return View();

    }
}