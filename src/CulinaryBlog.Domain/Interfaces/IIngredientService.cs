using CulinaryBlog.Domain.Entities;

namespace CulinaryBlog.Domain.Interfaces;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> GetIngredientsWithIngredientCategory();
    Task<IEnumerable<Ingredient>> GetIngredientsByIngredientCategory(Guid uuid);
}