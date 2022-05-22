using CulinaryBlog.Domain.Dto;
using CulinaryBlog.Domain.Entities;

namespace CulinaryBlog.Domain.Interfaces;

public interface IIngredientCategoryService
{
    Task<IEnumerable<IngredientCategory>> GetIngredientCategories();
    Task<IngredientCategory> GetIngredientCategory(Guid uuid);
    public Task<IngredientCategory> CreateIngredientCategory(CreateIngredientCategoryDto ingredientCategory);
}