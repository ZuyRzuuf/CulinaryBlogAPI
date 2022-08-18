using System.Data;
using CulinaryBlog.Domain.Dto;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Exceptions;
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
        const string query = "SELECT * FROM ingredient_category ic LEFT JOIN ingredient i on ic.uuid = i.ingredient_category";

        using var connection = _mysqlContext.CreateConnection();
        var ingredientCategoriesDictionary = new Dictionary<Guid, IngredientCategory>();
        var ingredientsCategories = await connection.QueryAsync<IngredientCategory, Ingredient, IngredientCategory>(
            query, (ingredientCategory, ingredient) =>
            {
                if (!ingredientCategoriesDictionary.TryGetValue(ingredientCategory.Uuid, out var ingredientCategoryEntry))
                {
                    ingredientCategoryEntry = ingredientCategory;
                    ingredientCategoryEntry.Ingredients = new List<Ingredient>();
                    ingredientCategoriesDictionary.Add(ingredientCategoryEntry.Uuid, ingredientCategoryEntry);
                }

                ingredientCategoryEntry.Ingredients?.Add(ingredient);

                return ingredientCategoryEntry;
            },
            splitOn: "uuid"
        );

        return ingredientsCategories.Distinct().ToList();
    }

    public async Task<IngredientCategory> GetIngredientCategory(Guid uuid)
    {
        const string query = "SELECT * FROM ingredient_category ic INNER JOIN ingredient i on ic.uuid = i.ingredient_category WHERE ic.uuid = @Uuid";

        using var connection = _mysqlContext.CreateConnection();
        var ingredientCategoryDictionary = new Dictionary<Guid, IngredientCategory>();
        var ingredientsCategory = await connection.QueryAsync<IngredientCategory, Ingredient, IngredientCategory>(
            query, (ingredientCategory, ingredient) =>
            {
                if (ingredient.IngredientCategory != null) ingredient.IngredientCategory.Uuid = ingredientCategory.Uuid;
                
                if (ingredientCategoryDictionary.TryGetValue(ingredientCategory.Uuid,
                        out var existingIngredientCategory))
                {
                    ingredientCategory = existingIngredientCategory;
                }
                else
                {
                    ingredientCategory.Ingredients = new List<Ingredient>();
                    ingredientCategoryDictionary.Add(ingredientCategory.Uuid, ingredientCategory);
                }
                
                ingredientCategory.Ingredients?.Add(ingredient);

                return ingredientCategory;
            },
            splitOn: "uuid",
            param: new {uuid}
        );

        return ingredientsCategory.Distinct().SingleOrDefault() ?? throw new IngredientCategoryNotFoundException();
    }

    public async Task<IngredientCategory> CreateIngredientCategory(CreateIngredientCategoryDto ingredientCategoryDto)
    {
        const string query = "INSERT INTO ingredient_category (uuid, name) VALUES (@Uuid, @Name)";
        var uuid = Guid.NewGuid();
        var name = ingredientCategoryDto.Name;
        
        var parameters = new DynamicParameters();
        
        parameters.Add("Uuid", uuid, DbType.Guid);
        parameters.Add("Name", name, DbType.String);

        using var connection = _mysqlContext.CreateConnection();
        
        await connection.ExecuteAsync(query, parameters);

        return new IngredientCategory()
        {
            Uuid = uuid,
            Name = name
        };
    }

    public async Task<int> UpdateIngredientCategory(UpdateIngredientCategoryDto ingredientCategoryDto)
    {
        const string query = "UPDATE ingredient_category SET name = @Name WHERE uuid = @Uuid";
        var uuid = ingredientCategoryDto.Uuid;
        var name = ingredientCategoryDto.Name;

        var parameters = new DynamicParameters();
        
        parameters.Add("Uuid", uuid, DbType.Guid);
        parameters.Add("Name", name, DbType.String);
        
        using var connection = _mysqlContext.CreateConnection();
        
        return await connection.ExecuteAsync(query, parameters);
    }

    public async Task<int> DeleteIngredientCategory(Guid uuid)
    {
        const string query = "DELETE FROM ingredient_category WHERE uuid = @Uuid";
        
        var parameters = new DynamicParameters();
        
        parameters.Add("Uuid", uuid, DbType.Guid);
        
        using var connection = _mysqlContext.CreateConnection();
        
        return await connection.ExecuteAsync(query, new {uuid});
    }
}