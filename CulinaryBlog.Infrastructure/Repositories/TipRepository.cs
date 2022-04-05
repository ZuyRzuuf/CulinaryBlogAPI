using System;
using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Interfaces;

namespace CulinaryBlog.Infrastructure.Repositories
{
    public class TipRepository : ITipRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TipRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
