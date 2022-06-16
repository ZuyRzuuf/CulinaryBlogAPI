using System;
using System.Collections.Generic;
using System.Linq;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;

namespace CulinaryBlog.Infrastructure.Tests.Unit.Repositories;

public class IngredientRepositoryTest
{
    private Mock<IIngredientRepository> _mockRepository = null!;
    private IEnumerable<IngredientCategory> _ingredientCategoryInMemoryDatabase = new List<IngredientCategory>();
    private IEnumerable<Ingredient> _ingredientInMemoryDatabase = new List<Ingredient>();
    
    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IIngredientRepository>();
        _ingredientCategoryInMemoryDatabase = new List<IngredientCategory>
        {
            new() {Uuid = Guid.Parse("ab24fde6-495b-45b6-be3c-1343939b646a"), Name = "IngredientCategory 1"},
            new() {Uuid = Guid.Parse("fe0efe1e-eab7-4ca4-a059-e51de04b0eed"), Name = "IngredientCategory 2"},
            new() {Uuid = Guid.Parse("a4f5ceb4-3d74-444f-a05f-57e8cfd42061"), Name = "IngredientCategory 3"},
        };
        _ingredientInMemoryDatabase = new List<Ingredient>()
        {
            new() {
                Uuid = Guid.Parse("830e4e64-b5da-4a6a-b010-9e59704871ed"), 
                Name = "Ingredient 1", 
                IngredientCategory = _ingredientCategoryInMemoryDatabase.ToList()[0]
            },
            new() {
                Uuid = Guid.Parse("cc9da874-9f95-4d5d-9c0e-039802839778"), 
                Name = "Ingredient 2", 
                IngredientCategory = _ingredientCategoryInMemoryDatabase.ToList()[1]
            },
            new() {
                Uuid = Guid.Parse("88399577-8a71-4df8-8806-e7e8a99ee6f7"), 
                Name = "Ingredient 1", 
                IngredientCategory = _ingredientCategoryInMemoryDatabase.ToList()[0]
            }
        };
    }
    
    [Test]
    public void GetIngredientCategories_Returns_IngredientForIngredientCategory()
    {
        // _mockRepository.Setup(r => r.)
        // _mockRepository.Setup(r => r.GetIngredientCategories())
        //     .Returns(() => Task.FromResult(
        //         ingredientCategoryInMemoryDatabase
        //     ));
        //
        // var actual = _mockRepository.Object.GetIngredientCategories();
        //
        // Assert.NotNull(actual.Result);
        // Assert.AreEqual(ingredientCategoryInMemoryDatabase, actual.Result);
        
        Assert.Pass();
    }
}