using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Interfaces;
using Dapper;

namespace CulinaryBlog.Infrastructure.Repositories;

public class IngredientCategoryRepository : IIngredientCategoryRepository
{
    private readonly MysqlContext _mysqlContext;

    public IngredientCategoryRepository(MysqlContext mysqlContext)
    {
        _mysqlContext = mysqlContext;
    }

    public async Task<IEnumerable<IngredientCategory>> GetIngredientCategories()
    {
        const string query = "SELECT * FROM ingredient_category";

        using(var connection = _mysqlContext.CreateConnection())
        {
            var ingredientsCategories = await connection.QueryAsync<IngredientCategory>(query);

            return ingredientsCategories.ToList();
        }
    }
}