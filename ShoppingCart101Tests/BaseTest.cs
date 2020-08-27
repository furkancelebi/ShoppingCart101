using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Services;
using Infrastructure.Repositories;

namespace ShoppingCart101Tests
{
    public class BaseTest
    {
        protected IServiceCollection services;

        [OneTimeSetUp]
        public void ConfigureServices()
        {
            services = new ServiceCollection()
                .AddSingleton<ICategoryService, CategoryService>()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<ICartService, CartService>()
                .AddSingleton<IDeliveryService, DeliveryService>()
                .AddSingleton<ICouponService, CouponService>()
                .AddSingleton<ICategoryRepository, CategoryRepository>()
                .AddSingleton<IProductRepository, ProductRepository>()
                .AddSingleton<ICartRepository, CartRepository>()
                .AddSingleton<ICouponRepository, CouponRepository>();
        }
    }
}