using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OOPsIDidItAgain._01.SuperController.Web.Data;
using OOPsIDidItAgain._01.SuperController.Web.Models;
using OOPsIDidItAgain._01.SuperController.Web.Services;

namespace OOPsIDidItAgain._01.SuperController.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly INotifier _notifier;
        private readonly ILogger<CartsController> _logger;

        public CartsController(
            ICartRepository cartRepository,
            IItemRepository itemRepository,
            INotifier notifier,
            ILogger<CartsController> logger)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
            _notifier = notifier;
            _logger = logger;
        }

        [HttpGet("{cartId}")]
        public ActionResult<CartModel> Get(Guid cartId)
        {
            var cart = _cartRepository.Get(cartId);
            if (cart != null)
            {
                return MapToModel(cart);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CartModel> CreateCart()
            => MapToModel(_cartRepository.Save(new Cart()));


        [HttpPost("{cartId}/items")]
        public IActionResult AddItemToCart(Guid cartId, AddItemToCartModel addItemToCart)
        {
            _logger.LogInformation("Starting {actionName}", nameof(AddItemToCart));
            try
            {
                // do some validations
                if (cartId == default
                    || addItemToCart.ItemId == default
                    || addItemToCart.Quantity <= 0)
                {
                    return BadRequest();
                }

                var cart = _cartRepository.Get(cartId);
                if (cart is null)
                {
                    return NotFound();
                }

                var item = _itemRepository.Get(addItemToCart.ItemId);
                if (item is null)
                {
                    return NotFound();
                }

                var cartItem = cart.Items?.FirstOrDefault(i => i.ItemId == addItemToCart.ItemId);
                if (cartItem != null)
                {
                    // item already on cart
                    return BadRequest();
                }

                _logger.LogInformation("Checking if can add item to cart");

                if ((item.MaximumQuantity ?? int.MaxValue) < addItemToCart.Quantity)
                {
                    return BadRequest();
                }

                if ((item.MinimumTimeOfDayToSell ?? TimeSpan.Zero) > DateTime.Now.TimeOfDay)
                {
                    return BadRequest();
                }

                _logger.LogInformation("Adding item to cart");

                cartItem = new CartItem
                {
                    ItemId = addItemToCart.ItemId,
                    Quantity = addItemToCart.Quantity
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
                    _notifier.Notify(item.Id);
                }

                // ...                
                return NoContent();
            }
            finally
            {
                _logger.LogInformation("Ending {actionName}", nameof(AddItemToCart));
            }
        }

        [HttpPut("{cartId}/items/{itemId}")]
        public IActionResult UpdateItemInCart(Guid cartId, Guid itemId, UpdateItemInCart updateItemInCart)
        {
            // do some validations
            if (cartId == default
                || itemId == default
                || updateItemInCart.Quantity <= 0)
            {
                return BadRequest();
            }

            var cart = _cartRepository.Get(cartId);
            if (cart is null)
            {
                return NotFound();
            }

            var item = _itemRepository.Get(itemId);
            if (item is null)
            {
                return NotFound();
            }

            var cartItem = cart.Items?.FirstOrDefault(i => i.ItemId == itemId);
            if (cartItem is null)
            {
                return NotFound();
            }
            
            _logger.LogInformation("Checking if can add item to cart");
            if ((item.MaximumQuantity ?? int.MaxValue) < updateItemInCart.Quantity)
            {
                return BadRequest();
            }

            cartItem.Quantity = updateItemInCart.Quantity;

            _cartRepository.Save(cart);

            _logger.LogInformation("Checking if need to notify someone");
            if (item.IsInWatchlist)
            {
                _notifier.Notify(item.Id);
            }

            return NoContent();
        }

        [HttpDelete("{cartId}/items/{itemId}")]
        public IActionResult RemoveItemFromCart(Guid cartId, Guid itemId)
        {
            // do some validations
            if (cartId == default
                || itemId == default)
            {
                return BadRequest();
            }

            var cart = _cartRepository.Get(cartId);
            if (cart is null)
            {
                return NotFound();
            }
            
            var item = _itemRepository.Get(itemId);
            if (item is null)
            {
                return NotFound();
            }

            cart.Items = cart.Items.Where(i => i.ItemId != itemId);

            _cartRepository.Save(cart);

            _logger.LogInformation("Checking if need to notify someone");
            if (item.IsInWatchlist)
            {
                _notifier.Notify(item.Id);
            }

            return NoContent();
        }

        private CartModel MapToModel(Cart cart)
            => new CartModel
            {
                Id = cart.Id,
                Items = cart.Items?.Select(MapToModel) ?? Enumerable.Empty<CartItemModel>()
            };

        private CartItemModel MapToModel(CartItem cartItem)
            => new CartItemModel
            {
                ItemId = cartItem.ItemId,
                Quantity = cartItem.Quantity
            };
    }
}