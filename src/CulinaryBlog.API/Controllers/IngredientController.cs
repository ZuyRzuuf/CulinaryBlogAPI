using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryBlog.API.Controllers;

[Route("v1/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    [ActionName("IngredientWithIngredientCategory")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ingredient))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetIngredientWithIngredientCategory()
    {
        try{
            var ingredients = await _ingredientService.GetIngredientsWithIngredientCategory();

            return Ok(ingredients);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("ingredientCategoryUuid")]
    [ActionName("IngredientByIngredientCategoryUuid")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ingredient))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetIngredientsByIngredientCategoryUuid(Guid ingredientCategoryUuid)
    {
        try
        {
            var ingredients = await _ingredientService.GetIngredientsByIngredientCategory(ingredientCategoryUuid);

            return Ok(ingredients);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}