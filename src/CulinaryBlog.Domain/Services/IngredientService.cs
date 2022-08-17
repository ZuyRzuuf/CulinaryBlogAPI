using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;

namespace CulinaryBlog.Domain.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientService(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsWithIngredientCategory()
    {
        var response = await _ingredientRepository.GetIngredientsWithIngredientCategory();

        return response;
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsByIngredientCategory(Guid uuid)
    {
        var response = await _ingredientRepository.GetIngredientsByIngredientCategory(uuid);

        return response;
    }
}