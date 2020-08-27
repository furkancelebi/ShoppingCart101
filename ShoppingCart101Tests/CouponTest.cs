using Infrastructure.Services;
using Infrastructure.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using Infrastructure.Helpers;

namespace ShoppingCart101Tests
{
    public class CouponTest : BaseTest
    {
        private ICouponService _couponService;
        [SetUp]
        public void Setup()
        {
            _couponService = services.BuildServiceProvider().GetRequiredService<ICouponService>();
        }

        [Test]
        [TestCase("CouponTest", TestName = "ValidCoupon_Pass")]
        public void CreateCoupon_Success(string couponName)
        {
            var coupon = new AmountCoupon(couponName, 2, 2);

            Assert.IsTrue(!string.IsNullOrEmpty(coupon.Description));
        }

        [Test]
        [TestCase("", TestName = "CreateCoupon_NullValue_Fails")]
        [TestCase(" ", TestName = "CreateCoupon_WhiteSpaceValue_Fails")]
        public void CreateCoupon_Fail_EmptyTitle(string couponName)
        {
            Assert.Throws<CustomValidationException>(() => new AmountCoupon(couponName, 2, 2));
        }

        [Test]
        [TestCase(-1, TestName = "CreateCoupon_NegativeAmount_Fails")]
        public void CreateCoupon_Fail_NegativeAmount(double amount)
        {
            Assert.Throws<CustomValidationException>(() => new AmountCoupon("Coupon", amount, 2));
        }

        [Test]
        [TestCase(-1, TestName = "CreateCoupon_NegativeDiscountAmount_Fails")]
        public void CreateCoupon_Fail_NegativeDiscountAmount(double discountAmount)
        {
            Assert.Throws<CustomValidationException>(() => new AmountCoupon("Coupon", 2, discountAmount));
        }
    }
}