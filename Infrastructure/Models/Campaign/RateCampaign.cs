using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class RateCampaign : Campaign
    {
        public RateCampaign(string description, double amount, int quantity) : base(description, amount, quantity, DiscountTypeEnum.Rate)
        {

        }

        internal override double GetDiscountAmount(double controlAmount)
        {
            return (Amount / 100) * controlAmount;
        }
    }
}
