using CulinaryBlog.Domain.Dto;
using FluentValidation;

namespace CulinaryBlog.API.Validators;

public class UpdateIngredientCategoryDtoValidator : AbstractValidator<UpdateIngredientCategoryDto>
{
    public UpdateIngredientCategoryDtoValidator()
    {
        RuleFor(ingredientCategory => ingredientCategory.Uuid).NotNull().NotEmpty();
        RuleFor(ingredientCategory => ingredientCategory.Name).NotNull().NotEmpty();
    }
}