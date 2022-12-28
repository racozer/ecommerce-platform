using Platform.Services.Client.Product.Data.Entities;


namespace Platform.Services.Client.Product.Repository.Abstractions;

public interface IProductBrandRepository
{
    Task<ProductBrand> GetBrand(long id);

    IQueryable<ProductBrand> GetAllBrand();

    Task AddBrand(ProductBrand brand);

    Task SaveBrand();

    Task UpdateBrand(ProductBrand brand);

    Task DeleteBrand(long id);
}
