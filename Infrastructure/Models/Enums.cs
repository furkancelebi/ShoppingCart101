﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public enum DiscountTypeEnum
    {
        Rate,
        Amount
    }

    public enum DeliveryPriceEnum
    {
        FixedPrice,
        PerCategoryPrice,
        PerProductPrice
    }

    public enum CampaignTypeEnum
    {
        RateCampaign20PercentFor3Items,
        AmountCampaign50TLFor5Items,
        RateCampaign50percentFor5Items
    }

    public enum ProductTypeEnum
    {
        ProductPrice10,
        ProductPrice50,
        ProductPrice250
    }
}