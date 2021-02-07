using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.PostAddItemToCartListeners;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers
{
    public class AddItemToCartHandler2 : IRequestHandler<AddItemToCartRequest, Either<Error, Unit>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IItemSaleRuleRepository _itemSaleRuleRepository;
        
        private readonly IPostAddItemToCartListener _listener;

        public AddItemToCartHandler2(
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

        public Either<Error, Unit> Handle(AddItemToCartRequest input)
        {
            var maybeCart = _cartRepository.Get(input.CartId);
            if (!maybeCart.TryGetValue(out var cart))
            {
                return Either.Left<Error, Unit>(new Error.NotFound("Couldn't find the cart"));
            }
            var item = _itemRepository.Get(input.ItemId);
            if (item is null)
            {
                return Either.Left<Error, Unit>(new Error.NotFound("Couldn't find the item"));
            }

            var rules = _itemSaleRuleRepository.GetForItem(item.Id);
            return rules
                .Validate(cart, item, input.Quantity)
                .FlatMap(_ => cart.AddItemToCart(item, input.Quantity))
                .Do(_ => _cartRepository.Save(cart))
                .Do(cartItem => _listener.OnAdded(cart, item, cartItem))
                .Map(_ => Unit.Instance);
        }
    }
}