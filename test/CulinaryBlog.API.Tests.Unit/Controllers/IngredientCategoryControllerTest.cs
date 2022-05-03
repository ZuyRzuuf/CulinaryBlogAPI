using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace CulinaryBlog.API.Tests.Unit.Controllers;

[TestFixture]
public class IngredientCategoryControllerTest
{
    private Mock<IIngredientCategoryService> _mockIngredientCategoryService = default!;
    
    [SetUp]
    public void Setup()
    {
        _mockIngredientCategoryService = new Mock<IIngredientCategoryService>();
    }

    [Test]
    public void Test1()
    {
        IEnumerable<IngredientCategory> ingredientCategoryInMemoryDatabase = new List<IngredientCategory>
        {
            new() {Name = "IngredientCategory_1"},
            new() {Name = "IngredientCategory_2"},
            new() {Name = "IngredientCategory_3"},
        };
        
        _mockIngredientCategoryService.Setup(s => s.GetIngredientCategories())
            .Returns(() => Task.FromResult(ingredientCategoryInMemoryDatabase));
        
        Assert.Pass();
    }
}