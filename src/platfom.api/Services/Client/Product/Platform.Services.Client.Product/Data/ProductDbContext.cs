using Microsoft.EntityFrameworkCore;
using Platform.Services.Client.Product.Data.Entities;

namespace Platform.Services.Client.Product.Data;

public class ProductDbContext : DbContext
{
    public const string Schema = "Products";

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    public DbSet<Entities.Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
