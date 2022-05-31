using CulinaryBlog.Domain.Dto;
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
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    [HttpGet("{uuid:guid}")]
    [ActionName("IngredientCategoryByUuid")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IngredientCategory))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IngredientCategory))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateIngredientCategory(CreateIngredientCategoryDto ingredientCategory)
    {
        try
        {
            var createdIngredientCategory =
                await _ingredientCategoryService.CreateIngredientCategory(ingredientCategory);

            return CreatedAtAction(
                "IngredientCategoryByUuid", 
                new {uuid = createdIngredientCategory.Uuid}, 
                createdIngredientCategory
            );
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateIngredientCategory(UpdateIngredientCategoryDto ingredientCategoryDto)
    {
        try
        {
            var response = await _ingredientCategoryService.UpdateIngredientCategory(ingredientCategoryDto);

            if (response == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteIngredientCategory(Guid uuid)
    {
        try
        {
            var response = await _ingredientCategoryService.DeleteIngredientCategory(uuid);

            if (response == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}