using System;
using System.Collections.Concurrent;
using System.Linq;

namespace OOPsIDidItAgain._01.SuperController.Web.Data
{
    public class CartRepository : ICartRepository
    {
        private static readonly ConcurrentDictionary<Guid, Cart> Carts = new ConcurrentDictionary<Guid, Cart>();
        
        public Cart Get(Guid id) 
            => Carts.TryGetValue(id, out var cart) ? CloneCart(cart) : null;

        public Cart Save(Cart cart)
        {
            var toAddOrUpdate = CloneCart(cart);
            
            if (toAddOrUpdate.Id == default)
            {
                toAddOrUpdate.Id = Guid.NewGuid();
            }

            return Carts.AddOrUpdate(cart.Id, toAddOrUpdate, (id, existingCart) => toAddOrUpdate);
        }

        public void Delete(Guid id)
        {
            Carts.TryRemove(id, out _);
        }

        // just to simulate actually going to the DB, not acting on the same instance
        private Cart CloneCart(Cart cart)
            => new Cart
            {
                Id = cart.Id,
                Items = cart.Items?.Select(CloneCartItem) ?? Enumerable.Empty<CartItem>()
            };
        
        private CartItem CloneCartItem(CartItem cartItem)
            => new CartItem
            {
                ItemId = cartItem.ItemId,
                Quantity = cartItem.Quantity
            };
    }
}