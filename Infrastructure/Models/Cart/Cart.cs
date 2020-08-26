using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Infrastructure.Models
{
    public class Cart : BaseEntity
    {
        public List<CartItem> CartItemList { get; } = new List<CartItem>();

        private Coupon appliedCoupon;

        public void AddItem(CartItem newItem)
        {
            var _cartItem = CartItemList.Find(x => x.Product.Id == newItem.Product.Id);

            if (_cartItem != null)
            {
                _cartItem.Quantity += newItem.Quantity;
            }
            else
            {
                _cartItem = newItem;
                CartItemList.Add(_cartItem);
            }
        }

        public double GetCartTotalAmount()
        {
            return CartItemList.Sum(x => x.Product.Price * x.Quantity);
        }

        public double GetCampaignDiscount()
        {
            double campaignDiscountAmount = 0;
            var cartCategories = GetCartCategories();

            foreach (var item in cartCategories)
            {
                campaignDiscountAmount += item.categoryDiscountAmount;
            }

            return campaignDiscountAmount;
        }

        public double GetCouponDiscount()
        {
            var cartAmountAfterCampaignDiscount = GetCartAmountAfterCampaignDiscount();

            return (appliedCoupon?.GetDiscountAmount(cartAmountAfterCampaignDiscount)) ?? 0;
        }

        public double GetCartTotalAmountAfterDiscounts()
        {
            return GetCartAmountAfterCampaignDiscount() - GetCouponDiscount();
        }

        public double GetDeliveryCost()
        {
            return new DeliveryService().CalculateDeliveryCost(this);
        }

        public void ApplyCoupon(Coupon coupon)
        {
            if (coupon.IsApplicable(GetCartAmountAfterCampaignDiscount()))
                appliedCoupon = coupon;
        }

        public IEnumerable<CartCategory> GetCartCategories()
        {
            return CartItemList
               .GroupBy(x => x.Product.Category)
               .Select(y => new CartCategory()
               {
                   category = y.Key,
                   categoryTotalAmount = y.Sum(t => t.Product.Price * t.Quantity),
                   categoryTotalItemCount = y.Sum(t => t.Quantity),
                   products = y.Select(t=> new CartItem(t.Product, t.Quantity)).ToList()
               });
        }

        public double GetCartAmountAfterCampaignDiscount()
        {
            return GetCartTotalAmount() - GetCampaignDiscount();
        }

        public int CategoryCount
        {
            get { return GetCartCategories().Count(); }
        }

        public int ProductCount
        {
            get { return CartItemList.Count(); }
        }
    }
}