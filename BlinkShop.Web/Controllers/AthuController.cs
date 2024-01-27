using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using BlinkShop.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BlinkShop.Web.Controllers;

public class AthuController : Controller
{
    private readonly IAthuService _athuService;
    private readonly ITokenProvider _tokenProvider;
    public AthuController(IAthuService athuService, ITokenProvider tokenProvider)
    {
        _athuService = athuService;
        _tokenProvider = tokenProvider;
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
                await SiginUSerAsync(result);
                _tokenProvider.SetToken(result.Token);
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

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        _tokenProvider.ClearToken();
        return RedirectToAction("index", "Home");
    }
    private async Task SiginUSerAsync(LoginResponeseDto responeseDto)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(responeseDto.Token);
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

        var emailClaim = jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email);
        if (emailClaim != null)
        {
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, emailClaim.Value));
        }

        var uniqueNameClaim = jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.UniqueName);
        if (uniqueNameClaim != null)
        {
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.UniqueName, uniqueNameClaim.Value));
        }

        var subClaim = jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
        if (subClaim != null)
        {
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, subClaim.Value));
        }


        var RoleList = jwt.Claims.FirstOrDefault(x => x.Type == "role");
        if (RoleList!=null)
        {
            identity.AddClaim(new Claim(ClaimTypes.Role,RoleList.Value));
        }
        identity.AddClaim(new Claim(ClaimTypes.Name,uniqueNameClaim.Value));
        var principle = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);

    }
}