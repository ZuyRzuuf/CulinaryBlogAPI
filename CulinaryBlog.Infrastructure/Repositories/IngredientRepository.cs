using System;
using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Interfaces;

namespace CulinaryBlog.Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DatabaseContext _databaseContext;

        public IngredientRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
