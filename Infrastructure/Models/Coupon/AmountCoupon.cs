using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class AmountCoupon : Coupon
    {
        public AmountCoupon(string description, double minAmount, double discountAmount) : base(description, minAmount, discountAmount, DiscountTypeEnum.Amount)
        {
        }

        internal override double GetDiscountAmount(double controlAmount)
        {
            return DiscountAmount;
        }
    }
}