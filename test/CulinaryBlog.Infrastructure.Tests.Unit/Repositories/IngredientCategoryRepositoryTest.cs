using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using CulinaryBlog.Domain.Dto;
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
            new() {Uuid = Guid.Parse("ab24fde6-495b-45b6-be3c-1343939b646a"), Name = "IngredientCategory 1"},
            new() {Uuid = Guid.Parse("fe0efe1e-eab7-4ca4-a059-e51de04b0eed"), Name = "IngredientCategory 2"},
            new() {Uuid = Guid.Parse("a4f5ceb4-3d74-444f-a05f-57e8cfd42061"), Name = "IngredientCategory 3"},
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

    [Test]
    public async Task CreateIngredientCategory_ReturnsCreatedObject_WhenIngredientCategoryCreated()
    {
        var ingredientCategoryDto = new CreateIngredientCategoryDto()
        {
            Name = "test"
        };

        var uuid = Guid.NewGuid();
        
        _mockRepository.Setup(r => r.CreateIngredientCategory(ingredientCategoryDto))
            .Returns((IngredientCategoryDto dto) =>
            {
                var ingredientCategory = new IngredientCategory()
                {
                    Uuid = uuid,
                    Name = dto.Name
                };
        
                _ingredientCategoryInMemoryDatabase.ToList().Add(ingredientCategory);

                return Task.FromResult(ingredientCategory);
            });

        var created = await _mockRepository.Object.CreateIngredientCategory(ingredientCategoryDto);
        
        Assert.NotNull(created);
        Assert.IsInstanceOf<IngredientCategory>(created);
        Assert.AreEqual(uuid, created.Uuid);
        Assert.AreEqual(ingredientCategoryDto.Name, created.Name);
    }

    [Test]
    public async Task UpdateIngredientCategory_ReturnsTrue_WhenIngredientCategoryIsUpdated()
    {
        var uuid = Guid.Parse("fe0efe1e-eab7-4ca4-a059-e51de04b0eed");
        var ingredientCategoryDto = new UpdateIngredientCategoryDto()
        {
            Uuid = uuid,
            Name = "test"
        };

        _mockRepository.Setup(r => r.UpdateIngredientCategory(ingredientCategoryDto))
            .Returns((IngredientCategoryDto dto) =>
            {
                var ingredientCategoryList = _ingredientCategoryInMemoryDatabase.Where(ic => ic.Uuid == uuid).ToList();

                if (ingredientCategoryList.IsNullOrEmpty() || ingredientCategoryList.Count > 1) return Task.FromResult(0);
                
                ingredientCategoryList.ForEach(ic => ic.Name = ingredientCategoryDto.Name);

                var isUpdated = ingredientCategoryList.FirstOrDefault(ic => ic.Name == ingredientCategoryDto.Name);

                return Task.FromResult(isUpdated != null ? 1 : 0);
            });

        var isUpdated = await _mockRepository.Object.UpdateIngredientCategory(ingredientCategoryDto);
        
        Assert.AreEqual(1, isUpdated);
    }

    [Test]
    public async Task UpdateIngredientCategory_ReturnsFalse_WhenIngredientCategorWasNotFound()
    {
        var uuid = Guid.Parse("fe0efe1e-eab7-4ca4-b059-e51de04b0eed");
        var ingredientCategoryDto = new UpdateIngredientCategoryDto()
        {
            Uuid = uuid,
            Name = "test"
        };

        _mockRepository.Setup(r => r.UpdateIngredientCategory(ingredientCategoryDto))
            .Returns((IngredientCategoryDto dto) =>
            {
                var ingredientCategoryList = _ingredientCategoryInMemoryDatabase.Where(ic => ic.Uuid == uuid).ToList();

                if (ingredientCategoryList.IsNullOrEmpty() || ingredientCategoryList.Count > 1) return Task.FromResult(0);
                
                ingredientCategoryList.ForEach(ic => ic.Name = ingredientCategoryDto.Name);

                var isUpdated = ingredientCategoryList.FirstOrDefault(ic => ic.Name == ingredientCategoryDto.Name);

                return Task.FromResult(isUpdated != null ? 1 : 0);
            });

        var isUpdated = await _mockRepository.Object.UpdateIngredientCategory(ingredientCategoryDto);
        
        Assert.AreEqual(0, isUpdated);
    }
}