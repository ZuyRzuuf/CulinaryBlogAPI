using System.ComponentModel.DataAnnotations;

namespace CulinaryBlog.Domain.Dto;

public class IngredientCategoryDto
{
    [Required]
    public string? Name { get; set; }
}