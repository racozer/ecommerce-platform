using Microsoft.EntityFrameworkCore;

using Platform.Api.Services.Client.Product.Data;
using Platform.Api.Services.Client.Product.Data.Entities;
using Platform.Api.Services.Client.Product.Exceptions;
using Platform.Api.Services.Client.Product.Repository.Abstractions;


namespace Platform.Api.Services.Client.Product.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ILogger<CategoryRepository> _logger;
    private readonly ProductDbContext _dbContext;


    public CategoryRepository(
        ILogger<CategoryRepository> logger,
        ProductDbContext dbContext
    )
    {
        _logger = logger;
        _logger.LogInformation("Category repository created.");
        _dbContext = dbContext;
    }


    public async Task<Category> GetCategory(long id)
    {
        Category? category = await _dbContext.Categories.FirstAsync(c => c.Id == id);

        if (category is not null) return category;

        throw new CategoryNotFoundException();
    }

    public IQueryable<Category> GetAllCategory()
    {
        return _dbContext.Categories.AsQueryable();
    }

    public async Task AddCategory(Category category)
    {
        category.Id = default;

        category.CreatedDate = DateTime.Now;

        await _dbContext.Categories.AddAsync(category);
    }

    public async Task SaveCategory()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCategory(Category entity)
    {
        Category category = await this.GetCategory(entity.Id);

        category.LastUpdatedDate = DateTime.Now;

        _dbContext.Categories.Update(category);
    }

    public async Task DeleteCategory(long id)
    {
        Category category = await this.GetCategory(id);

        _dbContext.Categories.Remove(category);
    }
}
