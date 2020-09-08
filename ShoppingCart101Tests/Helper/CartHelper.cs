using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart101Tests.Helper
{
    public static class CartHelper
    {
        internal static Cart GetCart(CartExamples cartExamples, int quantityFirstProduct, int quantitySecondProduct, int quantityThirdProduct)
        {
            switch (cartExamples)
            {
                case CartExamples.CartWith3Products2CategoriesWithCampaign:
                    return CartWith3Products2CategoriesWithCampaign(quantityFirstProduct, quantitySecondProduct, quantityThirdProduct);
                case CartExamples.CartWith3Products1CategoriesNoCampaign:
                    return CartWith3Products1CategoriesNoCampaign(quantityFirstProduct, quantitySecondProduct, quantityThirdProduct);
                case CartExamples.CartWith1Product1CategoryAmountCampaign:
                    return CartWith1Product1CategoriesAmountCampaign(quantityFirstProduct, quantitySecondProduct, quantityThirdProduct);
                default:
                    return new Cart();
            }
        }

        private static Cart CartWith3Products2CategoriesWithCampaign(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity)
        {
            Cart cart = new Cart();
            Category category = CategoryHelper.GetCategoryWithTwoCampaign();

            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice10, category), productPrice10Quantity));
            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice250, category), productPrice250Quantity));

            category = CategoryHelper.GetCategoryWithOneCampaign();
            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice50, category), productPrice50Quantity));

            return cart;
        }

        private static Cart CartWith3Products1CategoriesNoCampaign(int productPrice10Quantity, int productPrice250Quantity, int productPrice50Quantity)
        {
            Cart cart = new Cart();
            Category category = CategoryHelper.GetCategoryNoCampaign();

            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice10, category), productPrice10Quantity));
            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice250, category), productPrice250Quantity));
            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice50, category), productPrice50Quantity));

            return cart;
        }

        private static Cart CartWith1Product1CategoriesAmountCampaign(int productPrice2Quantity, int productPrice5Quantity, int productPrice10Quantity)
        {
            Cart cart = new Cart();
            Category category = CategoryHelper.GetCategoryWithTwoCampaign();

            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice2, category), productPrice2Quantity));
            cart.AddItem(new CartItem(ProductHelper.GetProduct(ProductTypeEnum.ProductPrice5, category), productPrice5Quantity));

            return cart;
        }

        public enum CartExamples
        {
            CartWith3Products2CategoriesWithCampaign,
            CartWith3Products1CategoriesNoCampaign,
            CartWith1Product1CategoryAmountCampaign
        }
    }
}