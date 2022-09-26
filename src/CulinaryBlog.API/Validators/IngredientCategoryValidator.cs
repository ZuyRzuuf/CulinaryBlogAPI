using CulinaryBlog.Domain.Entities;
using FluentValidation;

namespace CulinaryBlog.API.Validators;

public class IngredientCategoryValidator : AbstractValidator<IngredientCategory>
{
    public IngredientCategoryValidator()
    {
        RuleSet("Uuid", () =>
        {
            RuleFor(ic => ic.Uuid)
                .NotEmpty()
                .NotNull();

        });
        
        RuleSet("Name", () =>
        {
            RuleFor(ic => ic.Name).NotEmpty().NotNull();
        });
        
        RuleSet("IngredientCategory", () =>
        {
            RuleFor(ic => ic.Uuid).NotEmpty().NotNull();
            RuleFor(ic => ic.Name)
                .NotEmpty()
                .NotNull()
                .NotEqual("00000000-0000-0000-0000-000000000000");
        });
    }
}