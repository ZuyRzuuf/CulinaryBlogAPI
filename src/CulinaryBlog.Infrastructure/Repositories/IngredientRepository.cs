using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using CulinaryBlog.Infrastructure.Database;
using Dapper;

namespace CulinaryBlog.Infrastructure.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly MysqlContext _mysqlContext;

    public IngredientRepository(MysqlContext mysqlContext)
    {
        _mysqlContext = mysqlContext;
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsByIngredientCategory(Guid uuid)
    {
        const string query = "SELECT * FROM ingredient WHERE ingredient_category = @Uuid";
        
        using var connection = _mysqlContext.CreateConnection();
        var ingredients = await connection.QuerySingleOrDefaultAsync<IEnumerable<Ingredient>>(query, new {uuid});

        return ingredients;
    }

    public async Task<Ingredient> GetIngredientByUuid(Guid uuid)
    {
        const string query = "SELECT * FROM ingredient WHERE uuid = @Uuid";
        
        using var connection = _mysqlContext.CreateConnection();
        var ingredient = await connection.QuerySingleOrDefaultAsync<Ingredient>(query, new {uuid});

        return ingredient;
    }
}