using OOPsIDidItAgain._04.OOifying.Web.Services;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain.PostAddItemToCartListeners;

public class WatchlistNotifierListener : IPostAddItemToCartListener
{
    private readonly INotifier _notifier;
    private readonly HashSet<string> _itemsInWatchlist;

    public WatchlistNotifierListener(INotifier notifier, IReadOnlyCollection<string> itemsInWatchlist)
    {
        _notifier = notifier;
        _itemsInWatchlist = new HashSet<string>(itemsInWatchlist);
    }

    public void OnAdded(Cart cart, Item item, CartItem cartItem)
    {
        if (_itemsInWatchlist.Contains(item.Id))
        {
            _notifier.Notify(item.Id);
        }
    }
}
