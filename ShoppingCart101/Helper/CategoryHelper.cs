using System;
using Infrastructure.Models;
using Infrastructure.Services;

namespace ShoppingCart101.Helper
{
    internal static class CategoryHelper
    {
        internal static Category GetBookCategory()
        {
            var category = new Category("Book Category");

            category.AddCampaign(CampaignHelper.GetCampaign(CampaignTypeEnum.RateCampaign20PercentFor3Items));
            category.AddCampaign(CampaignHelper.GetCampaign(CampaignTypeEnum.AmountCampaign50TLFor5Items));

            return category;
        }

        internal static Category GetDVDCategory()
        {
            var category = new Category("DVD Category");

            category.AddCampaign(CampaignHelper.GetCampaign(CampaignTypeEnum.RateCampaign20PercentFor3Items));

            return category;
        }
    }
}