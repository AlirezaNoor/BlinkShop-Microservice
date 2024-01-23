 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlicnkShop.Service.Athu.Api.Data.Contexts;

public class AthuContext:IdentityDbContext<IdentityUser>
{
    public AthuContext(DbContextOptions<AthuContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}