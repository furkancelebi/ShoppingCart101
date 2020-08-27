using Infrastructure.Models;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public interface ICouponService
    {
        List<Coupon> GetCoupons();
        void AddCoupon(Coupon coupon);
    }
}