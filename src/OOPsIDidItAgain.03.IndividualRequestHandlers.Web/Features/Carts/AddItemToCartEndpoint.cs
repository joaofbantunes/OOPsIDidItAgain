using OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Exceptions;
using OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Handlers;

namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Features.Carts;

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
                        {
                            CartId = cartId,
                            ItemId = addItemToCart.ItemId,
                            Quantity = addItemToCart.Quantity
                        });

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