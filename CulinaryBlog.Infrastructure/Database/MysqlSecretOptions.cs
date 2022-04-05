using System;
using CulinaryBlog.Infrastructure.Interfaces;

namespace CulinaryBlog.Infrastructure.Database
{
    // Use option patterns for getting MysqlSecrets from configuration
    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0#bind-hierarchical-configuration-data-using-the-options-pattern
    public class MysqlSecretOptions : IDbSecret
    {
        public const string MysqlSecret = "MysqlSecret";
        public string Endpoint { get; set; }
        public string Password { get; set; }
        public string Schema { get; set; }
        public string User { get; set; }
    }
}
