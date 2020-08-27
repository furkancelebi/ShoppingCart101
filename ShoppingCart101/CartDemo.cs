using System;
using Infrastructure.Services;
using Infrastructure.Models;
using ShoppingCart101.Helper;
using System.Collections.Generic;

namespace ShoppingCart101
{
    class CartDemo
    {
        private readonly ICategoryService _categoryService;

        private readonly ICouponService _couponService;

        public CartDemo(ICategoryService categoryService, ICouponService couponService)
        {
            _categoryService = categoryService;
            _couponService = couponService;
        }

        public void Run()
        {
            PrintHelper.PrintLine("Welcome to ShoppingCart101 Demo", PrintHelper.PrintType.Level0);
            PrintHelper.PrintBlankLine(2);

            CreateCategories();
            CreateCoupons();
            CreateCarts();
        }

        private void CreateCarts()
        {
            var carts = new List<Cart>();

            carts.Add(CartHelper.Cart1());
            carts.Add(CartHelper.Cart2());
            carts.Add(CartHelper.Cart3());
            PrintHelper.Print(carts);
        }

        private void CreateCategories()
        {
            _categoryService.AddCategory(CategoryHelper.GetBookCategory());
            _categoryService.AddCategory(CategoryHelper.GetDVDCategory());
            PrintHelper.Print(_categoryService.GetCategories());
        }

        private void CreateCoupons()
        {
            _couponService.AddCoupon(CouponHelper.GetCoupon(CouponTypeEnum.AmountCoupon5For50));
            _couponService.AddCoupon(CouponHelper.GetCoupon(CouponTypeEnum.AmountCoupon50For300));
            _couponService.AddCoupon(CouponHelper.GetCoupon(CouponTypeEnum.RateCoupon10For150));
            PrintHelper.Print(_couponService.GetCoupons());
        }

        private void CreateCart()
        {
            _categoryService.AddCategory(new Category("Category1"));
            _categoryService.AddCategory(new Category("Category2"));

            foreach (var item in _categoryService.GetCategories())
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
