using CulinaryBlog.Domain;
using CulinaryBlog.Domain.Interfaces;
using CulinaryBlog.Domain.Services;
using CulinaryBlog.Infrastructure.Database;
using CulinaryBlog.Infrastructure.Helpers;
using CulinaryBlog.Infrastructure.Interfaces;
using CulinaryBlog.Infrastructure.Repositories;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<MysqlContext>();
builder.Services.AddScoped<IIngredientCategoryRepository, IngredientCategoryRepository>();
builder.Services.AddScoped<IIngredientCategoryService, IngredientCategoryService>();
builder.Services.RegisterDataServices();
SqlMapper.AddTypeHandler(new MySqlGuidTypeHandler());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();