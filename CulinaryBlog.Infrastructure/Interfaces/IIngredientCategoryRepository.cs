using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryBlog.Domain.Entities;

namespace CulinaryBlog.Infrastructure.Interfaces
{
    public interface IIngredientCategoryRepository
    {
        public Task<IEnumerable<IngredientCategory>> GetIngredientCategories();
    }
}
