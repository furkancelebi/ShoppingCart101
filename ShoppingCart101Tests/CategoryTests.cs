using Infrastructure.Services;
using Infrastructure.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using Infrastructure.Helpers;

namespace ShoppingCart101Tests
{
    public class CategoryTests : BaseTest
    {
        private ICategoryService _categoryService;
        [SetUp]
        public void Setup()
        {
            _categoryService = services.BuildServiceProvider().GetRequiredService<ICategoryService>();
        }

        [Test]
        [TestCase("CategoryTest", TestName = "ValidCategory_Pass")]
        public void CreateCategory_Success(string categoryName)
        {
            var category = new Category(categoryName);

            Assert.IsTrue(!string.IsNullOrEmpty(category.Title));
        }

        [Test]
        [TestCase("", TestName = "NullValue_Fails")]
        [TestCase(" ", TestName = "WhiteSpaceValue_Fails")]
        public void CreateCategory_Fail_EmptyTitle_Fata(string categoryName)
        {
            Assert.Throws<CustomValidationException>(() => new Category(categoryName));
        }

        [Test]
        [TestCase("CategoryTest", TestName = "AddCategory")]
        public void AddCategory(string categoryName)
        {
            var category = new Category(categoryName);

            Assert.DoesNotThrow(() => _categoryService.AddCategory(category));
        }

        [Test]
        [TestCase(3, TestName = "AddMultipleCategory")]
        public void AddMultipleCategory(int categoryCount)
        {
            for (int i = 0; i < categoryCount; i++)
            {
                _categoryService.AddCategory(new Category($"CategoryName_{i}"));
            }

            Assert.AreEqual(categoryCount, _categoryService.GetCategories().Count);
        }

        [Test]
        [TestCase(3, TestName = "AddSameCategory_Fails")]
        public void AddSameCategory(int categoryCount)
        {
            var category = new Category($"CategoryName");

            Assert.Throws<Exception>(() => AddSameCategoryDelegate(category, categoryCount));
        }

        [Test]
        [TestCase("CategoryTest", TestName = "GetCategories")]
        public void GetCategories(string categoryName)
        {
            var category = new Category(categoryName);
            _categoryService.AddCategory(category);

            Assert.IsTrue(_categoryService.GetCategories().Count > 0);
        }

        #region Delegate Methods
        void AddSameCategoryDelegate(Category category, int categoryCount)
        {
            for (int i = 0; i < categoryCount; i++)
            {
                _categoryService.AddCategory(category);
            }
        }
        #endregion
    }
}