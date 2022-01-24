using OOPsIDidItAgain._04.OOifying.Web.Exceptions;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain;

public class Cart
{
    private readonly Dictionary<string, CartItem> _items;

    public Cart()
    {
        Id = Guid.NewGuid().ToString();
        _items = new Dictionary<string, CartItem>();
    }

    public string Id { get; }

    public IReadOnlyCollection<CartItem> Items => _items.Values;

    public CartItem AddItemToCart(Item item, int quantity)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new ValidationException($"Item {item.Id} already in the cart.");
        }

        var cartItem = new CartItem(item.Id, quantity);
        _items.Add(item.Id, cartItem);
        return cartItem;
    }

    public CartItem UpdateItemInCart(string itemId, int quantity)
    {
        if (!_items.ContainsKey(itemId))
        {
            throw new ValidationException($"Item {itemId} not in the cart.");
        }

        var cartItem = new CartItem(itemId, quantity);
        _items[itemId] = cartItem;
        return cartItem;
    }

    public void RemoveItemFromCart(string itemId)
    {
        _items.Remove(itemId);
    }
}
