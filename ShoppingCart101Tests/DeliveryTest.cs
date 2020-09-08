using Infrastructure.Services;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using ShoppingCart101Tests.Helper;

namespace ShoppingCart101Tests
{
    public class DeliveryTest : BaseTest
    {
        private IDeliveryService _deliveryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            _deliveryService = services.BuildServiceProvider().GetRequiredService<IDeliveryService>();
        }

        [Test]
        [TestCase(CartHelper.CartExamples.CartWith3Products2CategoriesWithCampaign, 3, 4, 3, TestName = "CalculateDeliveryCost", ExpectedResult = 9.99)]
        public double CalculateDeliveryCost(CartHelper.CartExamples cartExample, int quantity1, int quantity2, int quantity3)
        {
            Cart cart = CartHelper.GetCart(cartExample, quantity1, quantity2, quantity3);

            return _deliveryService.CalculateDeliveryCost(cart);
        }
    }
}