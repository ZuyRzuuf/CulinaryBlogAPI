using System.ComponentModel.DataAnnotations;

namespace CulinaryBlog.Domain.Dto;

public class CreateIngredientCategoryDto
{
    public Guid Uuid
    {
        get => Guid.NewGuid();
    }
    [Required]
    public string? Name { get; set; }
}