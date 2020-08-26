using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class AmountCampaign : Campaign
    {
        public AmountCampaign(string description, double amount, int quantity) : base(description, amount, quantity, DiscountTypeEnum.Amount)
        {

        }

        internal override double GetDiscountAmount(double controlAmount)
        {
            return Amount;
        }
    }
}