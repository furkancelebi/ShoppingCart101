using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart101Tests.Helper
{
    internal static class CampaignHelper
    {
        internal static Campaign GetCampaign(CampaignTypeEnum campaignType)
        {
            switch (campaignType)
            {
                case CampaignTypeEnum.RateCampaign20PercentFor3Items:
                    return new RateCampaign("3 adet üstü %20 İndirim", 20, 3);
                case CampaignTypeEnum.RateCampaign50percentFor5Items:
                    return new RateCampaign("5 adet üstü %50 İndirim", 50, 5);
                case CampaignTypeEnum.AmountCampaign50TLFor5Items:
                    return new AmountCampaign("5 adet üstü 50 TL İndirim", 50, 5);
                default:
                    throw new Exception("Campaign type not found");
            }
        }
    }
}
