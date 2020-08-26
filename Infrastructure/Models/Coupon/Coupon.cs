using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public abstract class Coupon : BaseEntity
    {
        public Coupon(string description, double minAmount, double discountAmount, DiscountTypeEnum discountType)
        {
            Description = description;
            MinAmount = minAmount;
            DiscountAmount = discountAmount;
            DiscountType = discountType;
        }

        public string Description { get; }
        public double MinAmount { get; }
        public double DiscountAmount { get; }
        public DiscountTypeEnum DiscountType { get; }

        internal bool IsApplicable(double cartAmountAfterCampaignDiscount)
        {
            return MinAmount <= cartAmountAfterCampaignDiscount;
        }

        internal abstract double GetDiscountAmount(double controlAmount);
    }
}