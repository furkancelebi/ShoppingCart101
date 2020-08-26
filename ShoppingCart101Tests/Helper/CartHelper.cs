using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart101Tests.Helper
{
    internal static class CartHelper
    {
        internal static Cart CartWith3Products2CategoriesWithCampaign(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity)
        {
            Cart cart = new Cart();
            Category category = CategoryHelper.GetCategoryWithTwoCampaign();

            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice10, category), productPrice10Quantity));
            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice250, category), productPrice250Quantity));

            category = CategoryHelper.GetCategoryWithOneCampaign();
            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice50, category), productPrice50Quantity));

            return cart;
        }

        internal static Cart CartWith3Products1CategoriesNoCampaign(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity)
        {
            Cart cart = new Cart();
            Category category = CategoryHelper.GetCategoryNoCampaign();

            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice10, category), productPrice10Quantity));
            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice250, category), productPrice250Quantity));
            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice50, category), productPrice50Quantity));

            return cart;
        }
    }
}