using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public abstract class Campaign : BaseEntity
    {
        [Required]
        public string Description { get; }
        public double Amount { get; }
        public int Quantity { get; }
        public DiscountTypeEnum DiscountType { get; }

        public Campaign(string description, double amount, int quantity, DiscountTypeEnum discountType)
        {
            Description = description;
            Amount = amount;
            Quantity = quantity;
            DiscountType = discountType;
        }

        internal abstract double GetDiscountAmount(double controlAmount);

        internal bool IsApplicable(int controlValue)
        {
            return Quantity <= controlValue;
        }
    }
}
