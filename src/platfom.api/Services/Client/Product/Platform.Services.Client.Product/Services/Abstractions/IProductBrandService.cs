using Platform.Services.Client.Product.DTOs;

namespace Platform.Services.Client.Product.Services.Abstractions; 

public interface IProductBrandService 
{
    Task<ProductBrandDto> GetBrandById(long id);

    Task<List<ProductBrandDto>> GetAllBrand();

    Task AddBrand(ProductBrandDto request);

    Task UpdateBrand(ProductBrandDto request);

    Task DeleteBrand(long id);
}
