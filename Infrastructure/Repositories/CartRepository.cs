using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class CartRepository : RepositoryBase<string, Cart>, ICartRepository
    {
        private List<Cart> _carts = new List<Cart>();

        public CartRepository()
        {

        }
    }
}