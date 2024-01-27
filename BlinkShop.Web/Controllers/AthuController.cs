using System.Net.Mime;
using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using BlinkShop.Web.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BlinkShop.Web.Controllers;

public class AthuController : Controller
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
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDto requestDto)
    {
        if (requestDto!=null)
        {
            var response = await _athuService.Login(requestDto);
            if (response!=null&&response.Success)
            {
                var result = JsonConvert.DeserializeObject<LoginResponeseDto>(Convert.ToString(response.Result));
                return RedirectToAction("index", "Home");
            }
        }
        return View(requestDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> Regestration()
    {
        var list = new List<SelectListItem>()
        {
            new SelectListItem() { Text = SD.Admin, Value = SD.Admin },
            new SelectListItem() { Text = SD.Costumer, Value = SD.Costumer }
        };
        ViewBag.List = list;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Regestration(RegestrationRequestDto dto)
    {
        var result = await _athuService.Regitertion(dto);
        if (result.Success)
        {
            if (string.IsNullOrEmpty(dto.role))
            {
                dto.role = SD.Costumer;
            }

            var role = await _athuService.Addrole(dto);
            if (role.Success)
            {
                return RedirectToAction("Login");
            }
        }

        var list = new List<SelectListItem>()
        {
            new SelectListItem() { Text = SD.Admin, Value = SD.Admin },
            new SelectListItem() { Text = SD.Costumer, Value = SD.Costumer }
        };
        ViewBag.List = list;

        return View();
    }
}