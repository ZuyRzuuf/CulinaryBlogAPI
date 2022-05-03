using CulinaryBlog.Domain.Entities;

namespace CulinaryBlog.Domain.Interfaces;

public interface IIngredientCategoryService
{
    Task<IEnumerable<IngredientCategory>> GetIngredientCategories();
    Task<IngredientCategory> GetIngredientCategory(Guid uuid);
}