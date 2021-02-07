using System;
using System.Collections.Generic;
using OOPsIDidItAgain._04.OOifying.Web.Services;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain.PostAddItemToCartListeners
{
    public class WatchlistNotifierListener : IPostAddItemToCartListener
    {
        private readonly INotifier _notifier;
        private readonly HashSet<Guid> _itemsInWatchlist;

        public WatchlistNotifierListener(INotifier notifier, IReadOnlyCollection<Guid> itemsInWatchlist)
        {
            _notifier = notifier;
            _itemsInWatchlist = new HashSet<Guid>(itemsInWatchlist);
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