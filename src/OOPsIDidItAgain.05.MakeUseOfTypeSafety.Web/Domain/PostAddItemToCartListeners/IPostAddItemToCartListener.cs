namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain.PostAddItemToCartListeners;

public interface IPostAddItemToCartListener
{
    void OnAdded(Cart cart, Item item, CartItem cartItem);
}
