using System;
using System.Collections.Generic;
using Infrastructure.Repositories;
using Infrastructure.Models;
using System.Linq;

namespace Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddCart(Cart cart)
        {
            _cartRepository.Add(cart.Id, cart);
        }

        public Cart GetCart(string cartGuid)
        {
            return _cartRepository.Find(cartGuid);
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.Update(cart.Id, cart);
        }

        public void AddItem(Cart cart, CartItem newItem)
        {
            cart.AddItem(newItem);

            UpdateCart(cart);
        }
    }
}