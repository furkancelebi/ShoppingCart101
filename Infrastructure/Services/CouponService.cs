using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Repositories;
using Infrastructure.Models;

namespace Infrastructure.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public List<Coupon> GetCoupons()
        {
            return _couponRepository.GetList();
        }

        public void AddCoupon(Coupon coupon)
        {
            var categories = GetCoupons();

            if (categories.Find(x => x.Id == coupon.Id) != null)
            {
                throw new Exception("Coupon already exists!");
            }

            _couponRepository.Add(coupon.Id, coupon);
        }
    }
}