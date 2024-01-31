using BlinkShop.Services.ShopingCart.Model;
using Microsoft.EntityFrameworkCore;

namespace BlinkShop.Services.ShopingCart.Context.CartShopDbContext;

public class MyContext:DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<CartHeader> CratHeaders { get; set; }
    public DbSet<CardDtailes> CardDtailes { get; set; }
}