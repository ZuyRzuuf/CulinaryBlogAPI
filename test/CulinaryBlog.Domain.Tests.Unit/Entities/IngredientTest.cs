using System;
using CulinaryBlog.Domain.Entities;
using NUnit.Framework;

namespace CulinaryBlog.Domain.Tests.Unit.Entities;

[TestFixture]
public class IngredientTest
{
    private readonly Guid _guid = Guid.NewGuid();
    private const string Name = "IngredientName";

    private readonly IngredientCategory _ingredientCategory = new()
    {
        Name = "IngredientCategoryName"
    };
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void WhenAllFieldsAreInitialized_ThenShouldContainExpectedValues()
    {
        var ingredient = new Ingredient()
        {
            Name = Name,
            IngredientCategory = _ingredientCategory
        };

        Assert.AreNotEqual(ingredient.Uuid, _guid);
        Assert.AreEqual(ingredient.Name, Name);
        Assert.AreEqual(ingredient.IngredientCategory, _ingredientCategory);
    }

    [Test]
    public void WhenFieldsAreNotInitialized_ThenNameShouldBeNull()
    {
        var ingredient = new Ingredient();
    
        Assert.AreNotEqual(ingredient.Uuid, _guid);
        Assert.AreEqual(ingredient.Name, null);
        Assert.AreNotEqual(ingredient.IngredientCategory.Uuid, _guid);
        Assert.AreEqual(ingredient.IngredientCategory.Name, null);
    }
}