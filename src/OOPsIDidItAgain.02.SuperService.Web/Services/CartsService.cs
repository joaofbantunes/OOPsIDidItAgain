using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using OOPsIDidItAgain._02.SuperService.Web.Data;
using OOPsIDidItAgain._02.SuperService.Web.Exceptions;

namespace OOPsIDidItAgain._02.SuperService.Web.Services
{
    public class CartsService : ICartsService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly INotifier _notifier;
        private readonly ILogger<CartsService> _logger;

        public CartsService(
            ICartRepository cartRepository,
            IItemRepository itemRepository,
            INotifier notifier,
            ILogger<CartsService> logger)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
            _notifier = notifier;
            _logger = logger;
        }


        public Cart Get(Guid cartId)
            => _cartRepository.Get(cartId);
        
        
        public Cart CreateCart()
            => _cartRepository.Save(new Cart());

        
        public void AddItemToCart(Guid cartId, Guid itemId, int quantity)
        {
            _logger.LogInformation("Starting {actionName}", nameof(AddItemToCart));
            try
            {
                // do some validations
                if (cartId == default
                    || itemId == default
                    || quantity <= 0)
                {
                    throw new ValidationException("Something isn't valid");
                }

                var cart = _cartRepository.Get(cartId);
                if (cart is null)
                {
                    throw new NotFoundException("Couldn't find the cart");
                }

                var item = _itemRepository.Get(itemId);
                if (item is null)
                {
                    throw new NotFoundException("Couldn't find the item");
                }

                var cartItem = cart.Items?.FirstOrDefault(i => i.ItemId == itemId);
                if (cartItem != null)
                {
                    // item already on cart
                    throw new ValidationException("Item already on cart");
                }

                _logger.LogInformation("Checking if can add item to cart");

                if ((item.MaximumQuantity ?? int.MaxValue) < quantity)
                {
                    throw new ValidationException("Quantity not allowed");
                }

                if ((item.MinimumTimeOfDayToSell ?? TimeSpan.Zero) > DateTime.Now.TimeOfDay)
                {
                    throw new ValidationException("Can't buy that yet!");
                }

                _logger.LogInformation("Adding item to cart");

                cartItem = new CartItem
                {
                    ItemId = itemId,
                    Quantity = quantity
                };

                if (cart.Items is null)
                {
                    cart.Items = new[] {cartItem};
                }
                else
                {
                    cart.Items = cart.Items.Concat(new[] {cartItem});
                }

                _cartRepository.Save(cart);
                
                _logger.LogInformation("Checking if need to notify someone");
                if (item.IsInWatchlist)
                {
                    _notifier.Notify(itemId);
                }

                // ...                
            }
            finally
            {
                _logger.LogInformation("Ending {actionName}", nameof(AddItemToCart));
            }
        }
        
        public void UpdateItemInCart(Guid cartId, Guid itemId, int quantity)
        {
            // do some validations
            if (cartId == default
                || itemId == default
                || quantity <= 0)
            {
                throw new ValidationException("Something isn't valid");
            }

            var cart = _cartRepository.Get(cartId);
            if (cart is null)
            {
                throw new NotFoundException("Couldn't find the cart");
            }

            var item = _itemRepository.Get(itemId);
            if (item is null)
            {
                throw new NotFoundException("Couldn't find the item");
            }

            var cartItem = cart.Items?.FirstOrDefault(i => i.ItemId == itemId);
            if (cartItem is null)
            {
                throw new NotFoundException("Couldn't find the item on the cart");
            }

            _logger.LogInformation("Checking if can add item to cart");
            if ((item.MaximumQuantity ?? int.MaxValue) < quantity)
            {
                throw new ValidationException("Quantity not allowed");
            }

            cartItem.Quantity = quantity;

            _cartRepository.Save(cart);
            
            _logger.LogInformation("Checking if need to notify someone");
            if (item.IsInWatchlist)
            {
                _notifier.Notify(itemId);
            }
            
        }
        
        public void RemoveItemFromCart(Guid cartId, Guid itemId)
        {
            // do some validations
            if (cartId == default
                || itemId == default)
            {
                throw new ValidationException("Something isn't valid");
            }

            var cart = _cartRepository.Get(cartId);
            if (cart is null)
            {
                throw new NotFoundException("Couldn't find the cart");
            }
            
            var item = _itemRepository.Get(itemId);
            if (item is null)
            {
                throw new NotFoundException("Couldn't find the item");
            }

            cart.Items = cart.Items.Where(i => i.ItemId != itemId);

            _cartRepository.Save(cart);

            _logger.LogInformation("Checking if need to notify someone");
            if (item.IsInWatchlist)
            {
                _notifier.Notify(itemId);
            }
        }
    }
}