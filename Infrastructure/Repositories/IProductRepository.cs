using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<string, Product>
    {
    }
}