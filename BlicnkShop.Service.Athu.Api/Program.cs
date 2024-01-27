using BlicnkShop.Service.Athu.Api.Data.Contexts;
using BlicnkShop.Service.Athu.Api.model;
using BlicnkShop.Service.Athu.Api.Service;
using BlicnkShop.Service.Athu.Api.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AthuContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.Configure<JWTOption>(builder.Configuration.GetSection("ApiAthu:JWTOption"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AthuContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IAthuServices, AthuServices>();
builder.Services.AddScoped<IGwtgenerator, Gwtgenerator>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();