using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace CulinaryBlog.Infrastructure.Database
{
    public class DatabaseContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("local");
        }

        public IDbConnection CreateConnection()
            // => new SqlConnection(_connectionString);
            => new MySqlConnection(_connectionString);
    }
}
