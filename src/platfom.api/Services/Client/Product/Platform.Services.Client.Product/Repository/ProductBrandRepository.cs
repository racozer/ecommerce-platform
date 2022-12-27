using Platform.Services.Client.Product.Data.Entities;
using Platform.Services.Client.Product.Data;
using Platform.Services.Client.Product.Exceptions;
using Platform.Services.Client.Product.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Platform.Services.Client.Product.Repository;

public class ProductBrandRepository : IProductBrandRepository
{
    private readonly ILogger<ProductBrandRepository> _logger;
    private readonly ProductDbContext _dbContext;


    public ProductBrandRepository(
        ILogger<ProductBrandRepository> logger,
        ProductDbContext dbContext
    )
    {
        _logger = logger;
        _logger.LogInformation("Product Brand repository created.");
        _dbContext = dbContext;
    }


    public async Task<ProductBrand> GetBrand(long id)
    {
        ProductBrand? brand = await _dbContext.ProductBrands.FirstAsync(c => c.Id == id);

        if (brand is not null) return brand;

        throw new ProductBrandNotFoundException();
    }

    public IQueryable<ProductBrand> GetAllBrand()
    {
        return _dbContext.ProductBrands.AsQueryable();
    }

    public async Task AddBrand(ProductBrand brand)
    {
        brand.Id = default;

        brand.CreatedDate = DateTime.Now;

        brand.LastUpdatedDate = default;

        await _dbContext.ProductBrands.AddAsync(brand);
    }

    public async Task SaveBrand()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateBrand(ProductBrand entity)
    {
        ProductBrand brand = await GetBrand(entity.Id);

        brand.LastUpdatedDate = DateTime.Now;

        _dbContext.ProductBrands.Update(brand);
    }

    public async Task DeleteBrand(long id)
    {
        ProductBrand brand = await GetBrand(id);

        _dbContext.ProductBrands.Remove(brand);
    }
}
