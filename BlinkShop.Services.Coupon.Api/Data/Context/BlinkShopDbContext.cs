using Microsoft.EntityFrameworkCore;

namespace BlinkShop.Services.Coupon.Api.Data.Context;

public class BlinkShopDbContext : DbContext
{
    public BlinkShopDbContext(DbContextOptions<BlinkShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Models.Coupon>().HasData(
            new Models.Coupon()
            {
                CouponId = 1,
                CouponCode = "10OFf",
                DiscountAmount = 10,
                MinAmount = 20
            },
            new Models.Coupon()
            {
                CouponId = 2,
                CouponCode = "20OFf",
                DiscountAmount = 20,
                MinAmount = 40
            }
        );
    }

    public DbSet<Models.Coupon> model { get; set; }
}