using OOPsIDidItAgain._04.OOifying.Web.Exceptions;
using OOPsIDidItAgain._04.OOifying.Web.Handlers;

namespace OOPsIDidItAgain._04.OOifying.Web.Features.Carts;

public static class AddItemToCartEndpoint
{
    public static void MapEndpoint(WebApplication app)
        => app.MapPost(
            "api/carts/{cartId}/items",
            (string cartId, AddItemToCartDto addItemToCart,
                IRequestHandler<AddItemToCart.Request, AddItemToCart.Response> handler) =>
            {
                try
                {
                    _ = handler.Handle(
                        new AddItemToCart.Request
                        (
                            cartId,
                            addItemToCart.ItemId,
                            addItemToCart.Quantity
                        ));

                    return Results.NoContent();
                }
                catch (ValidationException vex)
                {
                    return Results.BadRequest(vex.Message);
                }
                catch (NotFoundException nex)
                {
                    return Results.NotFound(nex.Message);
                }
            });
}