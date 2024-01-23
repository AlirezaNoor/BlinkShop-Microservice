using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlicnkShop.Service.Athu.Api.model;

public class LoginResponeseDto
{
    public UserDto user { get; set; }
    public string Token { get; set; }
}