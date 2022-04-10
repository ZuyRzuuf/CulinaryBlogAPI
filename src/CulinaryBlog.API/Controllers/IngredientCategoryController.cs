using CulinaryBlog.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryBlog.API.Controllers;

[Route("v1/[controller]")]
public class IngredientCategoryController : ControllerBase
{
    private readonly IIngredientCategoryRepository _ingredientCategoryRepository;

    public IngredientCategoryController(IIngredientCategoryRepository ingredientCategoryRepository)
    {
        _ingredientCategoryRepository = ingredientCategoryRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetIngredientCategories()
    {
        try
        {
            var ingredientCategories = await _ingredientCategoryRepository.GetIngredientCategories();

            return Ok(ingredientCategories);
        }
        catch(Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}