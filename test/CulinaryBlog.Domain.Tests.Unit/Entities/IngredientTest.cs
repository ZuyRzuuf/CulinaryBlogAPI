using System;
using CulinaryBlog.Domain.Entities;
using NUnit.Framework;

namespace CulinaryBlog.Domain.Tests.Unit.Entities;

[TestFixture]
public class IngredientTest
{
    private readonly Guid _guid = Guid.NewGuid();
    private readonly string _name = "IngredientName";

    private readonly IngredientCategory _ingredientCategory = new IngredientCategory()
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
            Name = _name,
            IngredientCategory = _ingredientCategory
        };

        Assert.AreNotEqual(ingredient.UUID, _guid);
        Assert.AreEqual(ingredient.Name, _name);
        Assert.AreEqual(ingredient.IngredientCategory, _ingredientCategory);
    }

    [Test]
    public void WhenFieldsAreNotInitialized_ThenNameShuldBeNull()
    {
        var ingredient = new Ingredient();

        Assert.AreNotEqual(ingredient.UUID, _guid);
        Assert.AreEqual(ingredient.Name, null);
        Assert.AreNotEqual(ingredient.IngredientCategory.Uuid, _guid);
        Assert.AreEqual(ingredient.IngredientCategory.Name, null);
    }
}