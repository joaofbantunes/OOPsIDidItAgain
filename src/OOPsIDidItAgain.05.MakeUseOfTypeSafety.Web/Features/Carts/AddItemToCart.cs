using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain.PostAddItemToCartListeners;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Handlers;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Features.Carts;

public static class AddItemToCart
{
    public record Request(CartId CartId, ItemId ItemId, int Quantity) : IRequest<Unit>;

    public class Handler : IRequestHandler<Request, Unit>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IItemSaleRuleRepository _itemSaleRuleRepository;

        private readonly IPostAddItemToCartListener _listener;

        public Handler(
            ICartRepository cartRepository,
            IItemRepository itemRepository,
            IItemSaleRuleRepository itemSaleRuleRepository,
            IPostAddItemToCartListener listener)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
            _itemSaleRuleRepository = itemSaleRuleRepository;
            _listener = listener;
        }

        public Unit Handle(Request input)
        {
            var maybeCart = _cartRepository.Get(input.CartId);
            var cart = maybeCart.ValueOr(
                () => throw new DomainException(new ErrorDetail.NotFound("Couldn't find the cart")));

            var item = _itemRepository.Get(input.ItemId);
            if (item is null)
            {
                throw new DomainException(new ErrorDetail.NotFound("Couldn't find the item"));
            }

            var rules = _itemSaleRuleRepository.GetForItem(item.Id);
            rules.Validate(cart, item, input.Quantity);

            var cartItem = cart.AddItemToCart(item, input.Quantity);

            _cartRepository.Save(cart);

            _listener.OnAdded(cart, item, cartItem);

            return Unit.Instance;
        }
    }
}