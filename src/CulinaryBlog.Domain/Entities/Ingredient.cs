namespace CulinaryBlog.Domain.Entities;

public class Ingredient
{
    public Guid UUID { get; } = Guid.NewGuid();
    public string? Name { get; set; }

    public IngredientCategory IngredientCategory { get; set; } = new();
}