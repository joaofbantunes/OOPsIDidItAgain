using System;
using Microsoft.AspNetCore.Mvc;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Handlers;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Models;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        [HttpPost("{cartId}/items")]
        public IActionResult AddItemToCart(
            [FromRoute]CartId cartId,
            AddItemToCartModel addItemToCart,
            [FromServices] IRequestHandler<AddItemToCartRequest, Unit> handler)
            => handler
                .Handle(new AddItemToCartRequest(cartId, addItemToCart.ItemId, addItemToCart.Quantity))
                .ToActionResult();

                

        [HttpPut("{cartId}/items/{itemId}")]
        public IActionResult UpdateItemInCart([FromRoute]CartId cartId, [FromRoute]ItemId itemId, UpdateItemInCartModel updateItemInCart)
            => throw new NotImplementedException();

        [HttpGet("{cartId}")]
        public ActionResult<CartModel> Get([FromRoute] CartId cartId)
            => throw new NotImplementedException();

        [HttpPost]
        public ActionResult<CartModel> CreateCart()
            => throw new NotImplementedException();


        [HttpDelete("{cartId}/items/{itemId}")]
        public IActionResult RemoveItemFromCart([FromRoute]CartId cartId, [FromRoute]ItemId itemId)
            => throw new NotImplementedException();
    }
}