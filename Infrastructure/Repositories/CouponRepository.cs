using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class CouponRepository : RepositoryBase<string, Coupon>, ICouponRepository
    {
        private List<Coupon> _coupons;
        public CouponRepository()
        {
            _coupons = new List<Coupon>();
        }
    }
}