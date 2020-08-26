using Infrastructure.Models;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        void AddProduct(Product product);
    }
}