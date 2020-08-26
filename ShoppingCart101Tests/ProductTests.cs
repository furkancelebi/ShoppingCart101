using Infrastructure;
using Infrastructure.Helpers;
using Infrastructure.Models;
using NUnit.Framework;
using System;

namespace ShoppingCart101Tests
{
    public class ProductTests : BaseTest
    {
        private Category category;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            category = new Category("CategoryName");
        }

        [Test]
        [TestCase("Hede", 1.25, TestName = "AllParametersOK_Pass")]
        public void CreatePrduct_Validation_Success(string productName, double productPrice)
        {
            Product product = new Product(productName, productPrice, category);

            Assert.DoesNotThrow(() => new Product(productName, productPrice, category));
        }

        [Test]
        [TestCase("Hede", -1, TestName = "PriceNegative_Fails")]
        [TestCase("", 1.23, TestName = "ProductNameNull_Fails")]
        [TestCase("  ", 1.23, TestName = "ProductNameWhiteSpace_Fails")]
        public void CreatePrduct_Validation_Fail(string productName, double productPrice)
        {
            Assert.Throws<CustomValidationException>(() => new Product(productName, productPrice, category));
        }
    }
}