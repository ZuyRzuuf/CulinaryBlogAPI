using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Interfaces;
using Dapper;

namespace CulinaryBlog.Infrastructure.Repositories
{
    public class IngredientCategoryRepository : IIngredientCategoryRepository
    {
        private readonly DatabaseContext _databaseContext;

        public IngredientCategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<IngredientCategory>> GetIngredientCategories()
        {
            var query = "SELECT * FROM IngredientCategory";

            using(var connection = _databaseContext.CreateConnection())
            {
                var ingredientsCategories = await connection.QueryAsync<IngredientCategory>(query);

                return ingredientsCategories.ToList();
            }
        }
    }
}
