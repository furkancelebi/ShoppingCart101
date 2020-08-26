using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class RateCoupon : Coupon
    {
        public RateCoupon(string description, double minAmount, double discountAmount) : base(description, minAmount, discountAmount, DiscountTypeEnum.Rate)
        {
        }

        internal override double GetDiscountAmount(double controlAmount)
        {
            return (DiscountAmount / 100) * controlAmount;
        }
    }
}