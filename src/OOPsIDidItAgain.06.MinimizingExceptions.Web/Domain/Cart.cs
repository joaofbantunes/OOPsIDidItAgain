using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

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

    public Either<Error, CartItem> AddItemToCart(Item item, int quantity)
    {
        if (_items.ContainsKey(item.Id))
        {
            return Either.Left<Error, CartItem>(new Error.Invalid($"Item {item.Id} already in the cart."));
        }

        var cartItem = new CartItem(item.Id, quantity);
        _items.Add(item.Id, cartItem);
        return Either.Right<Error, CartItem>(cartItem);
    }

    public Either<Error, CartItem> UpdateItemInCart(ItemId itemId, int quantity)
    {
        if (!_items.ContainsKey(itemId))
        {
            return Either.Left<Error, CartItem>(new Error.Invalid($"Item {itemId} not in the cart."));
        }

        var cartItem = new CartItem(itemId, quantity);
        _items[itemId] = cartItem;
        return Either.Right<Error, CartItem>(cartItem);
    }

    public void RemoveItemFromCart(ItemId itemId)
    {
        _items.Remove(itemId);
    }
}
