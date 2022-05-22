using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using CulinaryBlog.Domain.Services;
using Moq;
using NUnit.Framework;

namespace CulinaryBlog.Domain.Tests.Unit.Services;

[TestFixture]
public class IngredientCategoryServiceTest
{
    private Mock<IIngredientCategoryRepository> _mockIngredientCategoryRepository = default!;
    private IIngredientCategoryService _service = default!;
    private IEnumerable<IngredientCategory> _ingredientCategoryInMemoryDatabase = default!;

    [SetUp]
    public void Setup()
    {
        _ingredientCategoryInMemoryDatabase = new List<IngredientCategory>()
        {
            new() {Uuid = Guid.Parse("ab24fde6-495b-45b6-be3c-1343939b646a"), Name = "IngredientCategory_1"},
            new() {Uuid = Guid.Parse("fe0efe1e-eab7-4ca4-a059-e51de04b0eed"), Name = "IngredientCategory_2"},
            new() {Uuid = Guid.Parse("a4f5ceb4-3d74-444f-a05f-57e8cfd42061"), Name = "IngredientCategory_3"},
        };;
        _mockIngredientCategoryRepository = new Mock<IIngredientCategoryRepository>();
        _service = new IngredientCategoryService(_mockIngredientCategoryRepository.Object);
    }

    [Test]
    public void IngredientCategoryService_ReturnsAllIngredientCategories_WhenRepositoryResponseContainsData()
    {
        _mockIngredientCategoryRepository.Setup(s => s.GetIngredientCategories())
            .Returns(() => Task.FromResult(_ingredientCategoryInMemoryDatabase));

        var actual = _service.GetIngredientCategories().Result;
        
        Assert.AreEqual(_ingredientCategoryInMemoryDatabase, actual);
    }

    [Test]
    public void IngredientCategoryService_ReturnsEmptyResponse_WhenRepositoryResponseIsEmpty()
    {
        IEnumerable<IngredientCategory> ingredientCategoryInMemoryDatabase = new List<IngredientCategory>();
        
        _mockIngredientCategoryRepository.Setup(s => s.GetIngredientCategories());

        var actual = _service.GetIngredientCategories().Result;
        
        Assert.AreEqual(ingredientCategoryInMemoryDatabase, actual);
    }

    [Test]
    public void IngredientCategoryService_ReturnsIngredientCategory_WhenUuidExists()
    {
        var ingredientCategory = _ingredientCategoryInMemoryDatabase.First();
        var guid = ingredientCategory.Uuid;
        
        _mockIngredientCategoryRepository.Setup(r => r.GetIngredientCategory(ingredientCategory.Uuid))
            .Returns((Guid uuid) =>
            {
                return Task.FromResult(
                    _ingredientCategoryInMemoryDatabase.Single(ic => ic.Uuid == uuid)
                );
            });

        var actual = _service.GetIngredientCategory(guid);
        
        Assert.AreEqual(_ingredientCategoryInMemoryDatabase.First(), actual.Result);
    }
}