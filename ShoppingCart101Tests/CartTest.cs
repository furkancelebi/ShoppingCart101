using Infrastructure.Services;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using ShoppingCart101Tests.Helper;

namespace ShoppingCart101Tests
{
    public class CartTest : BaseTest
    {
        private ICartService _cartService;
        private Product productPrice10;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            productPrice10 = ProductHelper.GetProduct(ProductTypeEnum.ProductPrice10, CategoryHelper.GetCategoryWithTwoCampaign());
        }

        [SetUp]
        public void Setup()
        {
            _cartService = services.BuildServiceProvider().GetRequiredService<ICartService>();
        }

        [Test]
        public void AddItemToCart()
        {
            Cart cart = new Cart();

            _cartService.AddItem(cart, new CartItem(productPrice10, 3));

            Assert.AreEqual(_cartService.GetCart(cart.Id).CartItemList.Count, 1);
        }

        [Test]
        public void AddSameItemToCartCheckItemCount()
        {
            Cart cart = new Cart();

            _cartService.AddItem(cart, new CartItem(productPrice10, 3));
            _cartService.AddItem(cart, new CartItem(productPrice10, 7));

            Assert.AreEqual(_cartService.GetCart(cart.Id).CartItemList.Count, 1);
        }

        [Test]
        public void AddSameItemToCartCheckQuantity()
        {
            Cart cart = new Cart();

            _cartService.AddItem(cart, new CartItem(productPrice10, 3));
            _cartService.AddItem(cart, new CartItem(productPrice10, 7));

            Assert.AreEqual(_cartService.GetCart(cart.Id).CartItemList[0].Quantity, 10);
        }

        [Test]
        public void AddTwoItemsCheckItemCount()
        {
            int itemCount = 2;
            Cart cart = new Cart();

            for (int i = 0; i < itemCount; i++)
            {
                Product product = new Product($"Product_{i}", i, new Category($"Category_{i}"));
                _cartService.AddItem(cart, new CartItem(product, 2));
            }

            Assert.AreEqual(_cartService.GetCart(cart.Id).CartItemList.Count, itemCount);
        }

        [Test]
        [TestCase(3, 4, 3, TestName = "GetCartTotalAmount_1180", ExpectedResult = 1180)]
        [TestCase(1, 0, 1, TestName = "GetCartTotalAmount_60", ExpectedResult = 60)]
        public double GetCartTotalAmount(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity)
        {
            Cart cart = CartHelper.CartWith3Products2CategoriesWithCampaign(productPrice10Quantity, productPrice250Quantity, productPrice50Quantity);

            return cart.GetCartTotalAmount();
        }

        [Test]
        [TestCase(3, 4, 3, TestName = "GetCampaignDiscount", ExpectedResult = 236)]
        public double GetCampaignDiscount(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity)
        {
            Cart cart = CartHelper.CartWith3Products2CategoriesWithCampaign(productPrice10Quantity, productPrice250Quantity, productPrice50Quantity);

            return cart.GetCampaignDiscount();
        }

        [Test]
        [TestCase(3, 4, 3, TestName = "GetCartAmountAfterCampaignDiscount", ExpectedResult = 944)]
        public double GetCartAmountAfterCampaignDiscount(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity)
        {
            Cart cart = CartHelper.CartWith3Products2CategoriesWithCampaign(productPrice10Quantity, productPrice250Quantity, productPrice50Quantity);

            return cart.GetCartAmountAfterCampaignDiscount();
        }

        [Test]
        [TestCase(3, 4, 3, true, TestName = "GetRateCouponDiscountAmount_188_8", ExpectedResult = 188.8)]
        [TestCase(3, 4, 3, false, TestName = "GetDiscountAmount_WithoutCOupon", ExpectedResult = 0)]
        [TestCase(1, 0, 0, true, TestName = "GetRateCouponDiscountAmount_0", ExpectedResult = 0)]
        public double GetCouponDiscount(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity, bool applyCoupon)
        {
            Cart cart = CartHelper.CartWith3Products2CategoriesWithCampaign(productPrice10Quantity, productPrice250Quantity, productPrice50Quantity);
            if (applyCoupon)
            {
                Coupon coupon = new RateCoupon("100 TL üzeri %20 İndirim", 100, 20);
                cart.ApplyCoupon(coupon);
            }

            return cart.GetCouponDiscount();
        }


        [Test]
        [TestCase(3, 4, 3, TestName = "GetCategoryCount", ExpectedResult = 2)]
        public double GetCategoryCount(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity)
        {
            Cart cart = CartHelper.CartWith3Products2CategoriesWithCampaign(productPrice10Quantity, productPrice250Quantity, productPrice50Quantity);

            return cart.CategoryCount;
        }

        [Test]
        [TestCase(3, 4, 3, TestName = "GetProductCount", ExpectedResult = 3)]
        public double GetProductCount(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity)
        {
            Cart cart = CartHelper.CartWith3Products2CategoriesWithCampaign(productPrice10Quantity, productPrice250Quantity, productPrice50Quantity);

            return cart.ProductCount;
        }
    }
}