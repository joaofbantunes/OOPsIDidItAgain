using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Features.Carts;

public static class GetCart
{
    public record Request(CartId CartId) : IRequest<Maybe<Response>>;

    public record Response(CartId CartId, IReadOnlyCollection<Response.CartItem> Items)
    {
        public record CartItem(ItemId ItemId, int Quantity);
    }

    public class Handler : IRequestHandler<Request, Maybe<Response>>
    {
        private readonly ICartRepository _cartRepository;

        public Handler(ICartRepository cartRepository) => _cartRepository = cartRepository;

        public Maybe<Response> Handle(Request input)
            => _cartRepository.Get(input.CartId).TryGetValue(out var cart)
                ? Maybe.Some(
                    new Response(
                        cart.Id,
                        cart.Items.Select(i => new Response.CartItem(i.ItemId, i.Quantity)).ToList()
                    ))
                : Maybe.None<Response>();
    }
}