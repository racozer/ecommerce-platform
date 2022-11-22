using Platform.Api.Services.Client.Product.DTOs;


namespace Platform.Api.Services.Client.Product.Services.Abstractions;

public interface ICategoryService
{
    Task<CategoryDto> GetCategoryById(long id);

    Task<List<CategoryDto>> GetAllCategory();

    Task<List<CategoryDto>> GetAllCategoryWithSubs();

    Task AddCategory(CategoryDto request);

    Task UpdateCategory(CategoryDto request);

    Task DeleteCategory(long id);
}
