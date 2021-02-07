using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OOPsIDidItAgain._04.OOifying.Web.Exceptions;
using OOPsIDidItAgain._04.OOifying.Web.Handlers;
using OOPsIDidItAgain._04.OOifying.Web.Models;

namespace OOPsIDidItAgain._04.OOifying.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ILogger<CartsController> _logger;

        public CartsController(
            ILogger<CartsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("{cartId}/items")]
        public IActionResult AddItemToCart(
            Guid cartId,
            AddItemToCartModel addItemToCart,
            [FromServices] IRequestHandler<AddItemToCartRequest, AddItemToCartResponse> handler)
        {
            _logger.LogInformation("Starting {actionName}", nameof(AddItemToCart));
            try
            {
                _ = handler.Handle(
                    new AddItemToCartRequest
                    (
                        cartId,
                        addItemToCart.ItemId,
                        addItemToCart.Quantity
                    ));

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
            => throw new NotImplementedException();

        [HttpGet("{cartId}")]
        public ActionResult<CartModel> Get(Guid cartId) => throw new NotImplementedException();

        [HttpPost]
        public ActionResult<CartModel> CreateCart() => throw new NotImplementedException();


        [HttpDelete("{cartId}/items/{itemId}")]
        public IActionResult RemoveItemFromCart(Guid cartId, Guid itemId)
            => throw new NotImplementedException();
    }
}