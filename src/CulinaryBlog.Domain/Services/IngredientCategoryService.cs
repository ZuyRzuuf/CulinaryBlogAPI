using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using CulinaryBlog.Infrastructure.Interfaces;

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
}