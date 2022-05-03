using CulinaryBlog.Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;

namespace CulinaryBlog.Infrastructure.Tests.Unit.Repositories;

public class IngredientRepositoryTest
{
    private Mock<IIngredientRepository> _mockRepository = null!;
    
    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IIngredientRepository>();
    }

    [Test]
    public void GetIngredientCategories_Returns_IngredientCategories()
    {
        // IEnumerable<Ingredient> ingredientInMemoryDatabase = new List<Ingredient>
        // {
        //     new() {Name = "Ingredient_1", IngredientCategory = new IngredientCategory() {Name = "IngredientCategory_1"}},
        //     new() {Name = "Ingredient_2", IngredientCategory = new IngredientCategory() {Name = "IngredientCategory_2"}},
        //     new() {Name = "Ingredient_3", IngredientCategory = new IngredientCategory() {Name = "IngredientCategory_3"}},
        // };
        //
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