using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CulinaryBlog.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CulinaryBlog.API.Controllers
{
    [Route("v1/[controller]")]
    public class IngredientCategoryController : ControllerBase
    {
        private readonly IIngredientCategoryRepository _ingredientCategoryRepository;

        public IngredientCategoryController(IIngredientCategoryRepository ingredientCategoryRepository)
        {
            _ingredientCategoryRepository = ingredientCategoryRepository;
        }

        // GET: api/values
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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
