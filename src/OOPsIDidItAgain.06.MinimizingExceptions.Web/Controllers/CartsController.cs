using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Models;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        [HttpPost("{cartId}/items")]
        public IActionResult AddItemToCart(
            [FromRoute]CartId cartId,
            AddItemToCartModel addItemToCart,
            [FromServices] IRequestHandler<AddItemToCartRequest, Either<Error, Unit>> handler)
            => handler
                .Handle(new AddItemToCartRequest(cartId, addItemToCart.ItemId, addItemToCart.Quantity))
                .ToActionResult();

        [HttpPut("{cartId}/items/{itemId}")]
        public IActionResult UpdateItemInCart([FromRoute]CartId cartId, [FromRoute]ItemId itemId, UpdateItemInCartModel updateItemInCart)
            => throw new NotImplementedException();

        [HttpGet("{cartId}")]
        public ActionResult<CartModel> Get(
            [FromRoute] CartId cartId,
            [FromServices] IRequestHandler<GetCartRequest, Either<Error, GetCartResponse>> handler)
            => handler
                .Handle(new GetCartRequest(cartId))
                .ToActionResult(response => new CartModel
                (
                    response.CartId,
                    response.Items.Select(i => new CartItemModel(i.ItemId, i.Quantity))
                ));

        [HttpPost]
        public ActionResult<CartModel> CreateCart()
            => throw new NotImplementedException();


        [HttpDelete("{cartId}/items/{itemId}")]
        public IActionResult RemoveItemFromCart([FromRoute]CartId cartId, [FromRoute]ItemId itemId)
            => throw new NotImplementedException();
    }
}