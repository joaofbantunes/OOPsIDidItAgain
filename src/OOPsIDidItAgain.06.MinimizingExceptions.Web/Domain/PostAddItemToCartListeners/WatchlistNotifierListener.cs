using System.Collections.Generic;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Services;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.PostAddItemToCartListeners
{
    public class WatchlistNotifierListener : IPostAddItemToCartListener
    {
        private readonly INotifier _notifier;
        private readonly HashSet<ItemId> _itemsInWatchlist;

        public WatchlistNotifierListener(INotifier notifier, IReadOnlyCollection<ItemId> itemsInWatchlist)
        {
            _notifier = notifier;
            _itemsInWatchlist = new HashSet<ItemId>(itemsInWatchlist);
        }

        public void OnAdded(Cart cart, Item item, CartItem cartItem)
        {
            if (_itemsInWatchlist.Contains(item.Id))
            {
                _notifier.Notify(item.Id);
            }
        }
    }
}