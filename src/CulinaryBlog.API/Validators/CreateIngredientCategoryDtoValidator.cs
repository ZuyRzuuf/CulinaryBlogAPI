using CulinaryBlog.Domain.Dto;
using FluentValidation;

namespace CulinaryBlog.API.Validators;

public class CreateIngredientCategoryDtoValidator : AbstractValidator<CreateIngredientCategoryDto>
{
    public CreateIngredientCategoryDtoValidator()
    {
        RuleFor(ingredientCategory => ingredientCategory.Name).NotNull().NotEmpty();
    }
}