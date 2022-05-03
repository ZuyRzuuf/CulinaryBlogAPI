using CulinaryBlog.Domain.Entities;

namespace CulinaryBlog.Domain.Interfaces;

public interface IIngredientCategoryRepository
{
    public Task<IEnumerable<IngredientCategory>> GetIngredientCategories();
    public Task<IngredientCategory> GetIngredientCategory(Guid uuid);
}