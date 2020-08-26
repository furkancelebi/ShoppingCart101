using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart101.Helper
{
    internal static class ProductHelper
    {
        internal static Product GetProduct(string productTitle, ProductTypeEnum productTypeEnum, Category category)
        {
            switch (productTypeEnum)
            {
                case ProductTypeEnum.ProductPrice10:
                    return new Product(productTitle, 10, category);
                case ProductTypeEnum.ProductPrice50:
                    return new Product(productTitle, 50, category);
                case ProductTypeEnum.ProductPrice250:
                    return new Product(productTitle, 250, category);
                default:
                    throw new Exception("ProductType not found!");
            }
        }
    }
}