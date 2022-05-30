using System.ComponentModel.DataAnnotations;

namespace CulinaryBlog.Domain.Dto;

public class UpdateIngredientCategoryDto
{
    public Guid Uuid { get; set; }
    [Required]
    public string? Name { get; set; }
}