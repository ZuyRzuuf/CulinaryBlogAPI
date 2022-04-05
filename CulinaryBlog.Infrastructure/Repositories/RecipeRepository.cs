using System;
using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Interfaces;

namespace CulinaryBlog.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RecipeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
