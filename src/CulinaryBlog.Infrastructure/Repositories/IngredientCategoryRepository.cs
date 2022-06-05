using System.Data;
using CulinaryBlog.Domain.Dto;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using CulinaryBlog.Infrastructure.Database;
using Dapper;

namespace CulinaryBlog.Infrastructure.Repositories;

public class IngredientCategoryRepository : IIngredientCategoryRepository
{
    private readonly MysqlContext _mysqlContext;

    public IngredientCategoryRepository(MysqlContext mysqlContext)
    {
        _mysqlContext = mysqlContext;
    }

    public async Task<IList<IngredientCategory>> GetIngredientCategories()
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