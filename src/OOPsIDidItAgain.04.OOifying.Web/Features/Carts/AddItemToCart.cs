using OOPsIDidItAgain._04.OOifying.Web.Domain;
using OOPsIDidItAgain._04.OOifying.Web.Domain.PostAddItemToCartListeners;
using OOPsIDidItAgain._04.OOifying.Web.Exceptions;
using OOPsIDidItAgain._04.OOifying.Web.Handlers;

namespace OOPsIDidItAgain._04.OOifying.Web.Features.Carts;

public static class AddItemToCart
{
    public record Request(string CartId, string ItemId, int Quantity) : IRequest<Response>;

    public record Response;

    public class Handler : IRequestHandler<Request, Response>
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

        public Response Handle(Request input)
        {
            var cart = _cartRepository.Get(input.CartId);
            if (cart is null)
            {
                throw new NotFoundException("Couldn't find the cart");
            }

            var item = _itemRepository.Get(input.ItemId);
            if (item is null)
            {
                throw new NotFoundException("Couldn't find the item");
            }

            var rules = _itemSaleRuleRepository.GetForItem(item.Id);
            rules.Validate(cart, item, input.Quantity);

            var cartItem = cart.AddItemToCart(item, input.Quantity);

            _cartRepository.Save(cart);

            _listener.OnAdded(cart, item, cartItem);

            // ...
            return new Response();
        }
    }
}