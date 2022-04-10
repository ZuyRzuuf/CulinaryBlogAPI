using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Interfaces;

namespace CulinaryBlog.Infrastructure.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly MysqlContext _mysqlContext;

    public IngredientRepository(MysqlContext mysqlContext)
    {
        _mysqlContext = mysqlContext;
    }
}