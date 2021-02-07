using System.Collections.Generic;
using System.Linq;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers
{
    public record GetCartRequest(CartId CartId) : IRequest<Either<Error, GetCartResponse>>;

    public record GetCartResponse(CartId CartId, IReadOnlyCollection<GetCartResponse.CartItem> Items)
    {
        public record CartItem(ItemId ItemId, int Quantity);
    }

    public class GetCartHandler : IRequestHandler<GetCartRequest, Either<Error, GetCartResponse>>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Either<Error, GetCartResponse> Handle(GetCartRequest input)
            => _cartRepository.Get(input.CartId).TryGetValue(out var cart)
                ? Either.Right<Error, GetCartResponse>(
                    new GetCartResponse(
                        cart.Id,
                        cart.Items.Select(i => new GetCartResponse.CartItem(i.ItemId, i.Quantity)).ToList()
                    ))
                : Either.Left<Error, GetCartResponse>(new Error.NotFound("Couldn't find the cart"));
    }
}