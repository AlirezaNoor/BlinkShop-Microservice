using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot();
var app = builder.Build();
var setting = builder.Configuration.GetSection("ApiAthu");
var secret = setting.GetValue<string>("SecretKey");
var Issuer = setting.GetValue<string>("Issuer");
var Audience = setting.GetValue<string>("Audience");
//-----
var key = Encoding.ASCII.GetBytes(secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
    x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = Issuer,
            ValidAudience = Audience,
            ValidateAudience = true,
            ValidateLifetime = true, 
        };
    });
app.MapGet("/", () => "Hello World!");
app.UseOcelot();
app.UseAuthentication();
app.UseAuthorization();

app.Run();