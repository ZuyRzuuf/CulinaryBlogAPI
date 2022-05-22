using CulinaryBlog.Domain.Dto;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;

namespace CulinaryBlog.Domain.Services;

public class IngredientCategoryService : IIngredientCategoryService
{
    private readonly IIngredientCategoryRepository _ingredientCategoryRepository;

    public IngredientCategoryService(IIngredientCategoryRepository ingredientCategoryRepository)
    {
        _ingredientCategoryRepository = ingredientCategoryRepository;
    }
    
    public Task<IEnumerable<IngredientCategory>> GetIngredientCategories()
    {
        var response = _ingredientCategoryRepository.GetIngredientCategories();
        
        return response;
    }

    public Task<IngredientCategory> GetIngredientCategory(Guid uuid)
    {
        var response = _ingredientCategoryRepository.GetIngredientCategory(uuid);

        return response;
    }

    public Task<IngredientCategory> CreateIngredientCategory(CreateIngredientCategoryDto ingredientCategory)
    {
        var response = _ingredientCategoryRepository.CreateIngredientCategory(ingredientCategory);

        return response;
    }
}