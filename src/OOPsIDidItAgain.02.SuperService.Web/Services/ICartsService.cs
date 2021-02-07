using System;
using OOPsIDidItAgain._02.SuperService.Web.Data;

namespace OOPsIDidItAgain._02.SuperService.Web.Services
{
    public interface ICartsService
    {
        Cart Get(Guid cartId);

        Cart CreateCart();

        void AddItemToCart(Guid cartId, Guid itemId, int quantity);

        void UpdateItemInCart(Guid cartId, Guid itemId, int quantity);

        void RemoveItemFromCart(Guid cartId, Guid itemId);
    }
}