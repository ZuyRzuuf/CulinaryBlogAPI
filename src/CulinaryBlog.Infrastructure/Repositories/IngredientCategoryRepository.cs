using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
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

        using var connection = _mysqlContext.CreateConnection();
        var ingredientsCategories = await connection.QueryAsync<IngredientCategory>(query);

        return ingredientsCategories.ToList();
    }

    public async Task<IngredientCategory> GetIngredientCategory(Guid uuid)
    {
        const string query = "SELECT * FROM ingredient_category WHERE uuid = @Uuid";

        using var connection = _mysqlContext.CreateConnection();
        var ingredientsCategory = await connection.QuerySingleOrDefaultAsync<IngredientCategory>(query, new {uuid});

        return ingredientsCategory;
    }
}