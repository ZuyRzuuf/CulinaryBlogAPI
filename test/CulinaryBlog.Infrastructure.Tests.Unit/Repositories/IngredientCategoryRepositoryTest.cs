using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;

namespace CulinaryBlog.Infrastructure.Tests.Unit.Repositories;

public class IngredientCategoryRepositoryTest
{
    private Mock<IIngredientCategoryRepository> _mockRepository = null!;
    
    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IIngredientCategoryRepository>();
    }

    [Test]
    public void GetIngredientCategories_Returns_IngredientCategories()
    {
        IEnumerable<IngredientCategory> ingredientCategoryInMemoryDatabase = new List<IngredientCategory>
        {
            new() {Name = "IngredientCategory_1"},
            new() {Name = "IngredientCategory_2"},
            new() {Name = "IngredientCategory_3"},
        };
        
        _mockRepository.Setup(r => r.GetIngredientCategories())
            .Returns(() => Task.FromResult(
                ingredientCategoryInMemoryDatabase
            ));

        // For GetByUUID
        // repository.Setup(r => r.GetIngredientCategories())
        //     .Returns(() =>
        //     {
        //         return Task.FromResult(
        //             ingredientCategoryInMemoryDatabase.Single(ic => ic.UUID == guid)
        //         );
        //     });
        //
        // or
        //
        // repository.Setup(r => r.GetIngredientCategories())
        //     .Returns((Guid guid) => ingredientCategoryInMemoryDatabase.Single(ic => ic.UUID == guid));
        
        var actual = _mockRepository.Object.GetIngredientCategories();

        Assert.NotNull(actual.Result);
        Assert.AreEqual(ingredientCategoryInMemoryDatabase, actual.Result);
    }
}