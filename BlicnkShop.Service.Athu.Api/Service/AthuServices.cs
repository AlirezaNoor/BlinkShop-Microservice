using BlicnkShop.Service.Athu.Api.Data.Contexts;
using BlicnkShop.Service.Athu.Api.model;
using BlicnkShop.Service.Athu.Api.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace BlicnkShop.Service.Athu.Api.Service;

public class AthuServices : IAthuServices
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AthuContext _athuContext;
    private readonly IGwtgenerator _gwtgenerator;

    public AthuServices(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
        AthuContext athuContext, IGwtgenerator gwtgenerator)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _athuContext = athuContext;
        _gwtgenerator = gwtgenerator;
    }

    public async Task<String> Regestration(RegestrationRequestDto regestrationRequestDto)
    {
        try
        {
            IdentityUser user = new()
            {
                UserName = regestrationRequestDto.UserName,
                Email = regestrationRequestDto.Email,
                PhoneNumber = regestrationRequestDto.PhoneNumber
            };
            var createuser = await _userManager.CreateAsync(user, regestrationRequestDto.password);
            if (createuser.Succeeded)
            {
                var Fu = _athuContext.Users.First(x => x.UserName == regestrationRequestDto.UserName);
                UserDto userDto = new()
                {
                    PhoneNumber = Fu.PhoneNumber,
                    Email = Fu.Email,
                    UserName = Fu.UserName,
                    Id = Fu.Id
                };
                return "";
            }
            else
            {
                return createuser.Errors.FirstOrDefault().Description;
            }
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return "not fond";
    }

    public async Task<LoginResponeseDto> Login(LoginRequestDto loginRequestDto)
    {
        var user = _athuContext.Users.FirstOrDefault(x => x.UserName.ToLower() == loginRequestDto.UserName.ToLower());
        bool logedin = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
        if (user != null && logedin)
        {
            UserDto userDto = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            var role = await _userManager.GetRolesAsync(user);
            LoginResponeseDto login = new()
            {
                user = userDto,
                Token = _gwtgenerator.GwrCreator(user,role)
            };

            return login;
        }

        return new LoginResponeseDto();
    }

    public async Task<bool> AddRole(string UserName, string roleName)
    {
        var user = _athuContext.Users.FirstOrDefault(x => x.UserName.ToLower() == UserName.ToLower());
        if (user != null)
        {
            if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
            }

            await _userManager.AddToRoleAsync(user, roleName);
            return true;
        }

        return false;
    }
}