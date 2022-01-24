using OOPsIDidItAgain._02.SuperService.Web.Data;

namespace OOPsIDidItAgain._02.SuperService.Web.Services;

public interface ICartsService
{
    Cart Get(string cartId);

    Cart CreateCart();

    void AddItemToCart(string cartId, string itemId, int quantity);

    void UpdateItemInCart(string cartId, string itemId, int quantity);

    void RemoveItemFromCart(string cartId, string itemId);
}