using Mapster;
using Platform.Services.Client.Product.Data.Entities;
using Platform.Services.Client.Product.DTOs;
using Platform.Services.Client.Product.Repository.Abstractions;
using Platform.Services.Client.Product.Services.Abstractions;

namespace Platform.Services.Client.Product.Services;

public class CategoryService : ICategoryService
{
    private readonly ILogger<CategoryService> _logger;
    private readonly ICategoryRepository _categoryRepository;


    public CategoryService(
        ILogger<CategoryService> logger,
        ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _logger.LogInformation("Category service created.");
        _categoryRepository = categoryRepository;
    }


    public Task<List<CategoryDto>> GetAllCategory()
    {
        var categories = _categoryRepository.GetAllCategory().Where(c => c.Id != 0).ToList();

        List<Category> result = new();

        foreach (Category category in categories)
            if (category.ParentId == 0) result.Add(category);

        return Task.FromResult(result.Adapt<List<CategoryDto>>().ToList());
    }

    public Task<List<CategoryDto>> GetAllCategoryWithSubs()
    {
        var categories = _categoryRepository.GetAllCategory().Where(c => c.Id != 0).ToList();

        return Task.FromResult(categories.Adapt<List<CategoryDto>>().ToList());
    }

    public async Task<CategoryDto> GetCategoryById(long id)
    {
        Category category = await _categoryRepository.GetCategory(id);

        return category.Adapt<CategoryDto>();
    }

    public async Task AddCategory(CategoryDto request)
    {
        if (request.ParentId != 0)
        {
            await _categoryRepository.GetCategory(request.ParentId);

            Category category = request.Adapt<Category>();
            await _categoryRepository.AddCategory(category);
            await _categoryRepository.SaveCategory();
        }
        else
        {
            Category category = request.Adapt<Category>();
            await _categoryRepository.AddCategory(category);
            await _categoryRepository.SaveCategory();
        }
    }

    public async Task UpdateCategory(CategoryDto request)
    {
        await _categoryRepository.UpdateCategory(request.Adapt<Category>());
        await _categoryRepository.SaveCategory();
    }

    public async Task DeleteCategory(long id)
    {
        Category entity = await _categoryRepository.GetCategory(id);

        var categories = _categoryRepository.GetAllCategory().Where(c => c.Id != 0).ToList();

        foreach (Category? category in categories)
            if (category.ParentId == entity.Id)
                await _categoryRepository.DeleteCategory(category.Id);


        await _categoryRepository.DeleteCategory(id);
        await _categoryRepository.SaveCategory();
    }
}
