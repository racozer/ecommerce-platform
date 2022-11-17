﻿using Microsoft.EntityFrameworkCore;


namespace Platform.Api.Services.Client.Product.Data;

public class ProductDbContext : DbContext
{
    public const string Schema = "Products";

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    public DbSet<Entities.Product> Products { get; set; }
    public DbSet<Entities.Category> Categories { get; set; }
    public DbSet<Entities.ProductBrand> ProductBrands { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
