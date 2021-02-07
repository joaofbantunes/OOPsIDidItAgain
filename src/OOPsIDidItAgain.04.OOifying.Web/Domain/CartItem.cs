using System;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain
{
    public class CartItem
    {
        public CartItem(Guid itemId, int quantity)
        {
            ItemId = itemId != default 
                ? itemId 
                : throw new ArgumentException($"{nameof(itemId)} cannot be the default value.", nameof(itemId));
            Quantity = quantity > 0 
                ? quantity 
                : throw new ArgumentException($"{nameof(quantity)} must be greater than 0..", nameof(quantity));
        }

        public Guid ItemId { get; }

        public int Quantity { get; }
    }
}