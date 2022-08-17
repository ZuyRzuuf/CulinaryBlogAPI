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

    public async Task<IEnumerable<Ingredient>> GetIngredientsWithIngredientCategory()
    {
        const string query = "SELECT * FROM ingredient INNER JOIN ingredient_category ic ON ic.uuid = ingredient.ingredient_category";
        // const string query = "SELECT * FROM ingredient";

        using var connection = _mysqlContext.CreateConnection();
        var ingredients = await connection.QueryAsync<Ingredient, IngredientCategory, Ingredient>(
            query, (ingredient, ingredientCategory) =>
            {
                ingredient.IngredientCategory = ingredientCategory;

                return ingredient;
            },
            splitOn: "ingredient_category"
        );

        return ingredients;
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsWithoutIngredientCategory()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsByIngredientCategory(Guid uuid)
    {
        const string query = "SELECT * FROM ingredient WHERE ingredient_category = @Uuid";
        
        using var connection = _mysqlContext.CreateConnection();
        var ingredients = await connection.QueryAsync<Ingredient>(query, new {uuid});

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