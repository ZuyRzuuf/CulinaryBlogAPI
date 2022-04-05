using System;

namespace CulinaryBlog.Domain.Entities
{
    public class Ingredient
    {
        public Guid UUID { get; set; }
        public string name { get; set; }

        public IngredientCategory ingredientCategory { get; set; } = new IngredientCategory();
    }
}
