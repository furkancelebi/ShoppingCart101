using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public interface ICartService
    {
        Cart GetCart(string cartGuid);
        void AddCart(Cart cart);
        void UpdateCart(Cart cart);
        void AddItem(Cart cart, CartItem newItem);
    }
}