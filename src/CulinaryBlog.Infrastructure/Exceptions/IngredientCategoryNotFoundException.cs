namespace CulinaryBlog.Infrastructure.Exceptions;

public class IngredientCategoryNotFoundException : Exception
{
    private const string ExceptionMessage = "Ingredient Category not found";
    
    public IngredientCategoryNotFoundException()
        : base(ExceptionMessage)
    {
    }

    public IngredientCategoryNotFoundException(string message)
        : base(message)
    {
    }

    public IngredientCategoryNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}