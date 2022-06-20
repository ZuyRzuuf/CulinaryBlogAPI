namespace CulinaryBlog.Domain.Entities;

public class Ingredient
{
    public Guid Uuid { get; set; }
    public string Name { get; set; } = default!;
    public IngredientCategory? IngredientCategory { get; set; }
}