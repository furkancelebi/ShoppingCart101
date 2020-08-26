using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<string, Product>, IProductRepository
    {
        private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>();
        }
    }   
}