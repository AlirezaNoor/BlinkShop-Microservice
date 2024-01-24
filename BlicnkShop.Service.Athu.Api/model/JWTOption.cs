using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlicnkShop.Service.Athu.Api.model;

public class JWTOption
{
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}