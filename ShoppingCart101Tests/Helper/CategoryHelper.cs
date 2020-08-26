using System;
using Infrastructure.Models;

namespace ShoppingCart101Tests.Helper
{
    internal class CategoryHelper
    {
        internal static Category GetCategoryWithTwoCampaign()
        {
            var category = new Category("Category1");

            category.AddCampaign(CampaignHelper.GetCampaign(CampaignTypeEnum.AmountCampaign50TLFor5Items));
            category.AddCampaign(CampaignHelper.GetCampaign(CampaignTypeEnum.RateCampaign20PercentFor3Items));

            return category;
        }

        internal static Category GetCategoryWithOneCampaign()
        {
            var category = new Category("Category2");

            category.AddCampaign(CampaignHelper.GetCampaign(CampaignTypeEnum.RateCampaign20PercentFor3Items));

            return category;
        }

        internal static Category GetCategoryNoCampaign()
        {
            var category = new Category("Category3");

            return category;
        }
    }
}