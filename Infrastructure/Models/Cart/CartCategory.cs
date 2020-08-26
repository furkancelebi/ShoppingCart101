using Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class CartCategory
    {
        public Category category { get; set; }
        public double categoryTotalAmount { get; set; }
        public int categoryTotalItemCount { get; set; }
        public List<CartItem> products;
        public double categoryDiscountAmount
        {
            get { return CalculateDiscount(); }
        }
        public Campaign appliedCampaign { get; set; }

        internal double CalculateDiscount()
        {
            double _categoryDiscountAmount = 0;
            foreach (var campaign in category.Campaigns)
            {
                if (campaign.IsApplicable(categoryTotalItemCount))
                {
                    var tempCategoryDiscountAmount = campaign.GetDiscountAmount(categoryTotalAmount);

                    if (tempCategoryDiscountAmount > _categoryDiscountAmount)
                    {
                        _categoryDiscountAmount = tempCategoryDiscountAmount;
                        appliedCampaign = campaign;
                    }
                }
            }

            return _categoryDiscountAmount;
        }
    }
}