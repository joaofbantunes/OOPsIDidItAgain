using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Infrastructure;

public class InMemoryCartRepository : ICartRepository
{
    private readonly List<Cart> _carts = new()
    {
        Cart.From(new CartId(Guid.Parse("b9ce4fbf-dd5a-45aa-8a03-0f7fd5ad9f6a")), Array.Empty<CartItem>()),
        Cart.From(new CartId(Guid.Parse("5562ece2-976f-4804-8e0a-0bdc4a7fe5c4")), Array.Empty<CartItem>())
    };

    public Maybe<Cart> Get(CartId id)
        => Maybe.FromNullable(_carts.FirstOrDefault(c => c.Id == id));

    public Cart Save(Cart cart)
    {
        // NOOP - we're doing stuff in memory for demo purposes

        return cart;
    }

    public void Delete(CartId id) => throw new NotImplementedException();
}
