using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Handlers;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Features.Carts;

public static class AddItemToCartEndpoint
{
    public static void MapEndpoint(WebApplication app)
        => app.MapPost(
            "api/carts/{cartId}/items",
            (CartId cartId,
                    AddItemToCartDto addItemToCart,
                    IRequestHandler<AddItemToCart.Request, Unit> handler)
                => handler
                    .Handle(new AddItemToCart.Request(cartId, addItemToCart.ItemId, addItemToCart.Quantity))
                    .ToResult());
}