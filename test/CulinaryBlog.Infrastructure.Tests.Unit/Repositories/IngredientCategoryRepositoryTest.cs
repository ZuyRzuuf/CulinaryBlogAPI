using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace CulinaryBlog.Infrastructure.Tests.Unit.Repositories;

public class IngredientCategoryRepositoryTest
{
    private Mock<IIngredientCategoryRepository> _mockRepository = null!;
    private IEnumerable<IngredientCategory> _ingredientCategoryInMemoryDatabase = new List<IngredientCategory>();
    
    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IIngredientCategoryRepository>();
        _ingredientCategoryInMemoryDatabase = new List<IngredientCategory>
        {
            new() {Uuid = Guid.Parse("ab24fde6-495b-45b6-be3c-1343939b646a"), Name = "IngredientCategory_1"},
            new() {Uuid = Guid.Parse("fe0efe1e-eab7-4ca4-a059-e51de04b0eed"), Name = "IngredientCategory_2"},
            new() {Uuid = Guid.Parse("a4f5ceb4-3d74-444f-a05f-57e8cfd42061"), Name = "IngredientCategory_3"},
        };
    }

    [Test]
    public void GetIngredientCategories_Returns_IngredientCategories()
    {
        _mockRepository.Setup(r => r.GetIngredientCategories())
            .Returns(() => Task.FromResult(
                _ingredientCategoryInMemoryDatabase
            ));

        var actual = _mockRepository.Object.GetIngredientCategories();

        Assert.NotNull(actual.Result);
        Assert.AreEqual(_ingredientCategoryInMemoryDatabase, actual.Result);
    }

    [Test]
    public void GetIngredientCategory_ReturnsIngredientCategory_WhenUuidExists()
    {
        var ingredientCategory = _ingredientCategoryInMemoryDatabase.First();
        
        _mockRepository.Setup(r => r.GetIngredientCategory(ingredientCategory.Uuid))
            .Returns((Guid uuid) =>
            {
                return Task.FromResult(
                    _ingredientCategoryInMemoryDatabase.Single(ic => ic.Uuid == uuid)
                );
            });

        var actual = _mockRepository.Object.GetIngredientCategory(ingredientCategory.Uuid);

        Assert.NotNull(actual.Result);
        Assert.AreEqual(_ingredientCategoryInMemoryDatabase.First(), actual.Result);
    }

    [Test]
    public void GetIngredientCategory_ReturnsNull_WhenUuidNotExists()
    {
        var guid = Guid.NewGuid();
        
        _mockRepository.Setup(r => r.GetIngredientCategory(guid))
            .Returns((Guid uuid) =>
            {
                return Task.FromResult(
                    _ingredientCategoryInMemoryDatabase.SingleOrDefault(ic => ic.Uuid == uuid)
                )!;
            });

        var actual = _mockRepository.Object.GetIngredientCategory(guid);

        Assert.Null(actual.Result);
    }
}