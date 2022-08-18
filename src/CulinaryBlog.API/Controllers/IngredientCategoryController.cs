using CulinaryBlog.Domain.Dto;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using CulinaryBlog.Infrastructure.Exceptions;
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetIngredientCategory(Guid uuid)
    {
        try
        {
            var ingredientCategory = await _ingredientCategoryService.GetIngredientCategory(uuid);

            return Ok(ingredientCategory);
        }
        catch (IngredientCategoryNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IngredientCategory))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateIngredientCategory([FromBody] CreateIngredientCategoryDto ingredientCategoryDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        
        try
        {
            var createdIngredientCategory =
                await _ingredientCategoryService.CreateIngredientCategory(ingredientCategoryDto);

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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateIngredientCategory([FromBody] UpdateIngredientCategoryDto ingredientCategoryDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        
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