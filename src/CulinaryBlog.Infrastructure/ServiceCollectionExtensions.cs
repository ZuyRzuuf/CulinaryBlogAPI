using CulinaryBlog.Domain.Interfaces;
using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Interfaces;
using CulinaryBlog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CulinaryBlog.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterDataServices(this IServiceCollection services)
    {
        services.AddSingleton<MysqlContext>();
        services.AddScoped<IIngredientCategoryRepository, IngredientCategoryRepository>();

        return services;
    }
}