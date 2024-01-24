using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlicnkShop.Service.Athu.Api.model;
using BlicnkShop.Service.Athu.Api.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BlicnkShop.Service.Athu.Api.Service;

public class Gwtgenerator : IGwtgenerator
{
    private readonly JWTOption _jwtOption;

    public Gwtgenerator(IOptions<JWTOption>  jwtOption)
    {
        _jwtOption = jwtOption.Value;
    }

    public string GwrCreator(IdentityUser user)
    {
        var Key = Encoding.ASCII.GetBytes(_jwtOption.SecretKey);
        var clims = new List<Claim>();
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email);
            new Claim(JwtRegisteredClaimNames.Sub, user.Id);
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName);
        }
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Audience = _jwtOption.Audience,
            Issuer = _jwtOption.Issuer,
            Expires = DateTime.UtcNow.AddDays(7),
            Subject = new ClaimsIdentity(clims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256)
        };
        var TokenHandler = new JwtSecurityTokenHandler();
        var Token = TokenHandler.CreateToken(tokenDescriptor);
        return TokenHandler.WriteToken(Token);
    }
}