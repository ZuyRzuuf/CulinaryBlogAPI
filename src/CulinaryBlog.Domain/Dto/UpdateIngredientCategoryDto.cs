using System.ComponentModel.DataAnnotations;

namespace CulinaryBlog.Domain.Dto;

public class UpdateIngredientCategoryDto : IngredientCategoryDto
{
    [Required]
    public Guid Uuid { get; set; }
}