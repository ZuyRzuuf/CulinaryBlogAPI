using System.Data;

namespace CulinaryBlog.Infrastructure.Interfaces;

public interface IDbContext
{
    public IDbConnection CreateConnection();
}