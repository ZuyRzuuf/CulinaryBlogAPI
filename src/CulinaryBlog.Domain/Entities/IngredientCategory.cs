namespace CulinaryBlog.Domain.Entities;

public class IngredientCategory
{
    public Guid UUID { get; } = Guid.NewGuid();
    public string? Name { get; set; }
}