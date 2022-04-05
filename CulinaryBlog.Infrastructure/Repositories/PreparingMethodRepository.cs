using System;
using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Interfaces;

namespace CulinaryBlog.Infrastructure.Repositories
{
    public class PreparingMethodRepository : IPreparingMethodRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PreparingMethodRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
