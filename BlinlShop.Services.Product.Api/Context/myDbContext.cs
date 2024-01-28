using BlinlShop.Services.Product.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace BlinlShop.Services.Product.Api.Context;

public class myDbContext : DbContext
{
    public myDbContext(DbContextOptions<myDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        for (int i = 3; i <= 202; i++)
        {
            modelBuilder.Entity<Products>().HasData(
                new Api.Model.Products()
                {
                    id = i,
                    name = $"Book{i}",
                    Description = $"This is book number {i} in our web site",
                    CategoryName = "book",
                    price = i * 10,  // Assuming a simple price calculation based on the ID
                    imgurl = $"https://picsum.photos/200/{300 + i}"
                }
            );
        }
    }

    public DbSet<Products> Products { get; set; }
}