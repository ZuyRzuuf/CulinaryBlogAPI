using CulinaryBlog.Domain.Entities;
using FluentValidation;

namespace CulinaryBlog.API.Validators;

public class IngredientCategoryValidator : AbstractValidator<IngredientCategory>
{
    public IngredientCategoryValidator()
    {
        RuleFor(ingredientCategory => ingredientCategory.Name).NotNull().NotEmpty();
    }
}