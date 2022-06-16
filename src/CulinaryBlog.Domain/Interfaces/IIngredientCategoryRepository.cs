using CulinaryBlog.Domain.Dto;
using CulinaryBlog.Domain.Entities;

namespace CulinaryBlog.Domain.Interfaces;

public interface IIngredientCategoryRepository
{
    public Task<IEnumerable<IngredientCategory>> GetIngredientCategories();
    public Task<IngredientCategory> GetIngredientCategory(Guid uuid);
    public Task<IngredientCategory> CreateIngredientCategory(CreateIngredientCategoryDto ingredientCategoryDto);
    public Task<int> UpdateIngredientCategory(UpdateIngredientCategoryDto ingredientCategoryDto);
    public Task<int> DeleteIngredientCategory(Guid uuid);
}