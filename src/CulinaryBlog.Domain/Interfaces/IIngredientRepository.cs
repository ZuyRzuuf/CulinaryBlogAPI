using CulinaryBlog.Domain.Entities;

namespace CulinaryBlog.Domain.Interfaces;

public interface IIngredientRepository
{
    public Task<IEnumerable<Ingredient>> GetIngredientsWithIngredientCategory();
    public Task<IEnumerable<Ingredient>> GetIngredientsWithoutIngredientCategory();
    public Task<IEnumerable<Ingredient>> GetIngredientsByIngredientCategory(Guid uuid);
    public Task<Ingredient> GetIngredientByUuid(Guid uuid);
    // public Task<int> CreateIngredient(CreateIngredientDto)
}