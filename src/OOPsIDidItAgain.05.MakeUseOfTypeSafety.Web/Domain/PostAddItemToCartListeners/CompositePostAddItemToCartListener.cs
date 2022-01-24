namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain.PostAddItemToCartListeners;

public class CompositePostAddItemToCartListener : IPostAddItemToCartListener
{
    private readonly IReadOnlyCollection<IPostAddItemToCartListener> _listeners;

    public CompositePostAddItemToCartListener(IReadOnlyCollection<IPostAddItemToCartListener> listeners)
    {
        _listeners = listeners;
    }

    public void OnAdded(Cart cart, Item item, CartItem cartItem)
    {
        foreach (var listener in _listeners)
        {
            listener.OnAdded(cart, item, cartItem);
        }
    }
}
