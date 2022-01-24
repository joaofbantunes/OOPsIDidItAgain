namespace OOPsIDidItAgain._04.OOifying.Web.Domain.PostAddItemToCartListeners;

public interface IPostAddItemToCartListener
{
    void OnAdded(Cart cart, Item item, CartItem cartItem);
}
