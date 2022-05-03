using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryBlog.API.Controllers;

[Route("v1/[controller]")]
public class IngredientCategoryController : ControllerBase
{
    private readonly IIngredientCategoryService _ingredientCategoryService;
    
    public IngredientCategoryController(IIngredientCategoryService ingredientCategoryService)
    {
        _ingredientCategoryService = ingredientCategoryService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IngredientCategory))]
    public async Task<IActionResult> GetIngredientCategories()
    {
        try
        {
            var ingredientCategories = await _ingredientCategoryService.GetIngredientCategories(); 
            
            return Ok(ingredientCategories);
        }
        catch(Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{uuid}", Name = "IngredientCategoryByUuid")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IngredientCategory))]
    public async Task<IActionResult> GetIngredientCategory(Guid uuid)
    {
        try
        {
            var ingredientCategory = await _ingredientCategoryService.GetIngredientCategory(uuid);

            return Ok(ingredientCategory);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}