using Microsoft.AspNetCore.Mvc.Filters;

namespace CulinaryBlog.API.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RequireNameInIngredientCategoryDtoAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.ActionArguments.TryGetValue("ingredientCategoryDto", out var dto);

        // var name = dto.Name;
        
        await next();
    }
}