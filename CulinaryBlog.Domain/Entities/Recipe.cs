using System;

namespace CulinaryBlog.Domain.Entities
{
    public class Recipe
    {
        public Guid UUID { get; set; }
        public string Title { get; set; }
        public Description Description { get; set; } = new Description();
        public PreparingMethod PreparingMethod { get; set; } = new PreparingMethod();
        public Tip Tip { get; set; } = new Tip();
    }
}
