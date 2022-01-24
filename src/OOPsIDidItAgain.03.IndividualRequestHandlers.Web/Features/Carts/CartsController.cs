using Microsoft.AspNetCore.Mvc;
using OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Exceptions;
using OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Handlers;

namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Features.Carts;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    [HttpPost("{cartId}/items")]
    public IActionResult AddItemToCart(
        string cartId,
        AddItemToCartDto addItemToCart,
        [FromServices] IRequestHandler<AddItemToCart.Request, AddItemToCart.Response> handler)
    {
        try
        {
            _ = handler.Handle(
                new AddItemToCart.Request
                {
                    CartId = cartId,
                    ItemId = addItemToCart.ItemId,
                    Quantity = addItemToCart.Quantity
                });

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
    }
    
    // ...
    // all the other endpoints
}
