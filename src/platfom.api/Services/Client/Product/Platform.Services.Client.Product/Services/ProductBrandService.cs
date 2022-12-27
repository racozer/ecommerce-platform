using Mapster;
using Platform.Services.Client.Product.Data.Entities;
using Platform.Services.Client.Product.DTOs;
using Platform.Services.Client.Product.Repository.Abstractions;
using Platform.Services.Client.Product.Services.Abstractions;


namespace Platform.Services.Client.Product.Services;

public class ProductBrandService : IProductBrandService
{
    private readonly ILogger<ProductBrandService> _logger;
    private readonly IProductBrandRepository _productBrandRepository;


    public ProductBrandService(
        ILogger<ProductBrandService> logger,
        IProductBrandRepository productBrandRepository)
    {
        _logger = logger;
        _logger.LogInformation("Product Brand service created.");
        _productBrandRepository = productBrandRepository;
    }


    public Task<List<ProductBrandDto>> GetAllBrand()
    {
        var brands = _productBrandRepository.GetAllBrand();

        return Task.FromResult(brands.Adapt<List<ProductBrandDto>>().ToList());
    }

    public async Task<ProductBrandDto> GetBrandById(long id)
    {
        ProductBrand brand = await _productBrandRepository.GetBrand(id);

        return brand.Adapt<ProductBrandDto>();
    }

    public async Task AddBrand(ProductBrandDto request)
    {
        ProductBrand brand = request.Adapt<ProductBrand>();

        await _productBrandRepository.AddBrand(brand);
        await _productBrandRepository.SaveBrand();
    }

    public async Task UpdateBrand(ProductBrandDto request)
    {
        await _productBrandRepository.UpdateBrand(request.Adapt<ProductBrand>());
        await _productBrandRepository.SaveBrand();
    }

    public async Task DeleteBrand(long id)
    {
        await _productBrandRepository.DeleteBrand(id);
        await _productBrandRepository.SaveBrand();
    }
}
