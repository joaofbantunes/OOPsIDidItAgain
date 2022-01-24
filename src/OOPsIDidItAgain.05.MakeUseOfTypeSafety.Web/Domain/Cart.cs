using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

public class Cart
{
    private readonly Dictionary<ItemId, CartItem> _items;

    private Cart(CartId cartId, IReadOnlyCollection<CartItem> cartItems)
    {
        Require.NotDefault(cartId, nameof(cartId));
        Require.NotNull(cartItems, nameof(cartItems));

        Id = cartId;
        _items = cartItems.ToDictionary(i => i.ItemId, i => i);
    }

    public static Cart New()
        => new Cart(CartId.New(), Array.Empty<CartItem>());

    public static Cart From(CartId cartId, IReadOnlyCollection<CartItem> cartItems)
        => new Cart(cartId, cartItems);

    public CartId Id { get; }

    public IReadOnlyCollection<CartItem> Items => _items.Values;

    public CartItem AddItemToCart(Item item, int quantity)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new DomainException(new ErrorDetail.Invalid($"Item {item.Id} already in the cart."));
        }

        var cartItem = new CartItem(item.Id, quantity);
        _items.Add(item.Id, cartItem);
        return cartItem;
    }

    public CartItem UpdateItemInCart(ItemId itemId, int quantity)
    {
        if (!_items.ContainsKey(itemId))
        {
            throw new DomainException(new ErrorDetail.Invalid($"Item {itemId} not in the cart."));
        }

        var cartItem = new CartItem(itemId, quantity);
        _items[itemId] = cartItem;
        return cartItem;
    }

    public void RemoveItemFromCart(ItemId itemId)
    {
        _items.Remove(itemId);
    }
}
