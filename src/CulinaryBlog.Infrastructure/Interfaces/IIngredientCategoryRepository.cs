using CulinaryBlog.Domain.Entities;

namespace CulinaryBlog.Infrastructure.Interfaces;

public interface IIngredientCategoryRepository
{
    public Task<IEnumerable<IngredientCategory>> GetIngredientCategories();
}