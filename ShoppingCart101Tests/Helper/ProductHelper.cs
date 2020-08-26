using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart101Tests.Helper
{
    internal static class ProductHelper
    {
        internal static Product GetProduct(ProductTypeEnum productTypeEnum, Category category)
        {
            switch (productTypeEnum)
            {
                case ProductTypeEnum.ProductPrice10:
                    return new Product("ProductPrice10", 10, category);
                case ProductTypeEnum.ProductPrice50:
                    return new Product("ProductPrice50", 50, category);
                case ProductTypeEnum.ProductPrice250:
                    return new Product("ProductPrice250", 250, category);
                default:
                    throw new Exception("ProductType not found!");
            }
        }
    }
}