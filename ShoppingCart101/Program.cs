using Microsoft.Extensions.DependencyInjection;
using System;
using Infrastructure.Services;
using Infrastructure.Repositories;

namespace ShoppingCart101
{
    class Program
    {
        public static ServiceProvider _serviceProvider { get; private set; }

        static void Main(string[] args)
        {
            ConfigureServices();

            _serviceProvider.GetRequiredService<CartDemo>().Run();

            Console.ReadLine();
        }

        private static void ConfigureServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<ICategoryService, CategoryService>()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<ICartService, CartService>()
                .AddSingleton<IDeliveryService, DeliveryService>()
                .AddSingleton<ICouponService, CouponService>()
                .AddSingleton<ICategoryRepository, CategoryRepository>()
                .AddSingleton<IProductRepository, ProductRepository>()
                .AddSingleton<ICartRepository, CartRepository>()
                .AddSingleton<ICouponRepository, CouponRepository>()
                .AddSingleton<CartDemo>()
                .BuildServiceProvider(true);
        }
    }
}
