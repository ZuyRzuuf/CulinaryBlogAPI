using System;
using CulinaryBlog.Domain.Entities;
using NUnit.Framework;

namespace CulinaryBlog.Domain.Tests.Unit.Entities;

[TestFixture]
public class IngredientCategoryTest
{
    private readonly Guid _emptyGuid = new();
    private string _name = "IngredientCategoryName";
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void WhenAllFieldsAreInitialized_ThenShouldContainExpectedValues()
    {
        var ingredientCategory = new IngredientCategory
        {
            Name = _name
        };

        Assert.AreNotEqual(ingredientCategory.UUID, _emptyGuid);
        Assert.AreEqual(ingredientCategory.Name, _name);
    }

    [Test]
    public void WhenNameIsNotInitialized_ThenNameShuldBeNull()
    {
        var ingredientCategory = new IngredientCategory();

        Assert.AreNotEqual(ingredientCategory.UUID, _emptyGuid);
        Assert.AreEqual(ingredientCategory.Name, null);
    }
}