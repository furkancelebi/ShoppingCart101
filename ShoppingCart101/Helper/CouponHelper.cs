using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart101.Helper
{
    internal static class CouponHelper
    {
        internal static Coupon GetCoupon(CouponTypeEnum couponType)
        {
            switch (couponType)
            {
                case CouponTypeEnum.AmountCoupon5For50:
                    return new AmountCoupon("50 TL'de 5 TL indirim", 50, 5);
                case CouponTypeEnum.AmountCoupon50For300:
                    return new AmountCoupon("300 TL'de 50 TL indirim", 300, 50);
                case CouponTypeEnum.RateCoupon10For150:
                    return new RateCoupon("150 TL'de %10 indirim", 150, 10);
                default:
                    throw new Exception("Coupon not found");
            }
        }
    }
}