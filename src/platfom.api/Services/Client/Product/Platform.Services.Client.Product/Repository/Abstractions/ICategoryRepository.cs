using Platform.Services.Client.Product.Data.Entities;


namespace Platform.Services.Client.Product.Repository.Abstractions;

public interface ICategoryRepository
{
    Task<Category> GetCategory(long id);

    IQueryable<Category> GetAllCategory();

    Task AddCategory(Category category);

    Task SaveCategory();

    Task UpdateCategory(Category category);

    Task DeleteCategory(long id);
}
