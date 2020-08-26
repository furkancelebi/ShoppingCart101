using System.Collections.Generic;
using Infrastructure.Repositories;
using Infrastructure.Models;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.Add(product.Id, product);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetList();
        }
    }
}