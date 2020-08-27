using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart101.Helper
{
    internal static class CartHelper
    {
        internal static Cart Cart1()
        {
            Cart cart = new Cart();

            //Add Book
            Category category = CategoryHelper.GetBookCategory();
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Gündeste", ProductTypeEnum.ProductPrice50, category), 2));
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Atlas Vazgeçti", ProductTypeEnum.ProductPrice10, category), 1));

            //Add DVD
            category = CategoryHelper.GetDVDCategory();
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Before Sunrise", ProductTypeEnum.ProductPrice50, category), 1));
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Before Sunset", ProductTypeEnum.ProductPrice50, category), 1));


            return cart;
        }

        internal static Cart Cart2()
        {
            Cart cart = new Cart();

            //Add Book
            Category category = CategoryHelper.GetBookCategory();
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Gündeste", ProductTypeEnum.ProductPrice50, category), 2));
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Atlas Vazgeçti", ProductTypeEnum.ProductPrice10, category), 2));
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Semerkant", ProductTypeEnum.ProductPrice10, category), 1));

            //Add DVD
            category = CategoryHelper.GetDVDCategory();
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Ahlat Ağacı", ProductTypeEnum.ProductPrice50, category), 1));
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Kader", ProductTypeEnum.ProductPrice50, category), 1));

            cart.ApplyCoupon(CouponHelper.GetCoupon(CouponTypeEnum.RateCoupon10For150));
            return cart;
        }

        internal static Cart Cart3()
        {
            Cart cart = new Cart();

            //Add DVD
            var category = CategoryHelper.GetDVDCategory();
            cart.AddItem(new CartItem(ProductHelper.GetProduct("Old Boy", ProductTypeEnum.ProductPrice50, category), 1));

            cart.ApplyCoupon(CouponHelper.GetCoupon(CouponTypeEnum.AmountCoupon5For50));

            return cart;
        }
    }
}