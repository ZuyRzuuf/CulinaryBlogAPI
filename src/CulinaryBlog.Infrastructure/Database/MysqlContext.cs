using System.Data;
using CulinaryBlog.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace CulinaryBlog.Infrastructure.Database;

public class MysqlContext : IDbContext
{
    private readonly string? _connectionString;

    public MysqlContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("local");
    }

    public IDbConnection CreateConnection()
        => new MySqlConnection(_connectionString);
}