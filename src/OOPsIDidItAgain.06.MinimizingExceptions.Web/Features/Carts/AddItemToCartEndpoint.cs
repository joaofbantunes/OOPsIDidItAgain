using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Features.Carts;

public static class AddItemToCartEndpoint
{
    public static void MapEndpoint(WebApplication app)
        => app.MapPost(
            "api/carts/{cartId}/items",
            (CartId cartId,
                    AddItemToCartDto addItemToCart,
                    IRequestHandler<AddItemToCart.Request, Either<Error, Unit>> handler)
                => handler
                    .Handle(new AddItemToCart.Request(cartId, addItemToCart.ItemId, addItemToCart.Quantity))
                    .ToResult());
}