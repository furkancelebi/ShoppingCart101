using System;
using System.Collections.Generic;
using Infrastructure.Repositories;
using Infrastructure.Models;

namespace Infrastructure.Services
{
    public class DeliveryService : IDeliveryService
    {
        private Dictionary<DeliveryPriceEnum, double> deliveryPrices = new Dictionary<DeliveryPriceEnum, double>()
        {
            {DeliveryPriceEnum.FixedPrice, 2.99 },
            {DeliveryPriceEnum.PerCategoryPrice, 2 },
            {DeliveryPriceEnum.PerProductPrice, 1 }
        };

        public double CalculateDeliveryCost(Cart cart)
        {
            return deliveryPrices[DeliveryPriceEnum.FixedPrice]
                  + deliveryPrices[DeliveryPriceEnum.PerCategoryPrice] * cart.CategoryCount
                  + deliveryPrices[DeliveryPriceEnum.PerProductPrice] * cart.ProductCount;
        }
    }
}