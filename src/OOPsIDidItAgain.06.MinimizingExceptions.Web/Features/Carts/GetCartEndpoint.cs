using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Features.Carts;

public static class GetCartEndpoint
{
    public static void MapEndpoint(WebApplication app)
        => app.MapGet(
            "api/carts/{cartId}",
            (CartId cartId,
                    IRequestHandler<GetCart.Request, Maybe<GetCart.Response>> handler)
                => handler
                    .Handle(new GetCart.Request(cartId))
                    .ToResult(response => new CartDto
                    (
                        response.CartId,
                        response.Items.Select(i => new CartItemDto(i.ItemId, i.Quantity))
                    )));
}