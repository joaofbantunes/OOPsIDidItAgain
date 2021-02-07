using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OOPsIDidItAgain._02.SuperService.Web.Data;
using OOPsIDidItAgain._02.SuperService.Web.Exceptions;
using OOPsIDidItAgain._02.SuperService.Web.Models;
using OOPsIDidItAgain._02.SuperService.Web.Services;

namespace OOPsIDidItAgain._02.SuperService.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartsService _cartsService;
        private readonly ILogger<CartsController> _logger;

        public CartsController(
            ICartsService cartsService,
            ILogger<CartsController> logger)
        {
            _cartsService = cartsService;
            _logger = logger;
        }

        [HttpGet("{cartId}")]
        public ActionResult<CartModel> Get(Guid cartId)
        {
            var cart = _cartsService.Get(cartId);
            if (cart != null)
            {
                return MapToModel(cart);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CartModel> CreateCart()
            => MapToModel(_cartsService.CreateCart());


        [HttpPost("{cartId}/items")]
        public IActionResult AddItemToCart(Guid cartId, AddItemToCartModel addItemToCart)
        {
            _logger.LogInformation("Starting {actionName}", nameof(AddItemToCart));
            try
            {
                _cartsService.AddItemToCart(cartId, addItemToCart.ItemId, addItemToCart.Quantity);
                return NoContent();
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (NotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            finally
            {
                _logger.LogInformation("Ending {actionName}", nameof(AddItemToCart));
            }
        }

        [HttpPut("{cartId}/items/{itemId}")]
        public IActionResult UpdateItemInCart(Guid cartId, Guid itemId, UpdateItemInCart updateItemInCart)
        {
            _logger.LogInformation("Starting {actionName}", nameof(UpdateItemInCart));
            try
            {
                _cartsService.UpdateItemInCart(cartId, itemId, updateItemInCart.Quantity);
                return NoContent();
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (NotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            finally
            {
                _logger.LogInformation("Ending {actionName}", nameof(UpdateItemInCart));
            }
        }

        [HttpDelete("{cartId}/items/{itemId}")]
        public IActionResult RemoveItemFromCart(Guid cartId, Guid itemId)
        {
            _logger.LogInformation("Starting {actionName}", nameof(UpdateItemInCart));
            try
            {
                _cartsService.RemoveItemFromCart(cartId, itemId);
                return NoContent();
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (NotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            finally
            {
                _logger.LogInformation("Ending {actionName}", nameof(UpdateItemInCart));
            }
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