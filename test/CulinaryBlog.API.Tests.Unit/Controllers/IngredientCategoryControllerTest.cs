using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryBlog.API.Controllers;
using CulinaryBlog.Domain.Entities;
using CulinaryBlog.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace CulinaryBlog.API.Tests.Unit.Controllers;

[TestFixture]
public class IngredientCategoryControllerTest
{
    private Mock<IIngredientCategoryService> _mockIngredientCategoryService = default!;
    private IngredientCategoryController _ingredientCategoryController = default!;
    
    [SetUp]
    public void Setup()
    {
        _mockIngredientCategoryService = new Mock<IIngredientCategoryService>();
    }

    [Test]
    public void Test1()
    {
        IList<IngredientCategory> ingredientCategoryInMemoryDatabase = new List<IngredientCategory>
        {
            new() {Name = "IngredientCategory_1"},
            new() {Name = "IngredientCategory_2"},
            new() {Name = "IngredientCategory_3"},
        };
        
        _mockIngredientCategoryService.Setup(s => s.GetIngredientCategories())
            .Returns(() => Task.FromResult(ingredientCategoryInMemoryDatabase));
        
        // var actual = _mockIngredientCategoryService.
        
        // var controllerAction = _ingredientCategoryController.GetIngredientCategories();
        
        Assert.Pass();
        // Assert.AreEqual(ingredientCategoryInMemoryDatabase.First(), );
    }
}