using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

public interface ICartRepository
{
    Maybe<Cart> Get(CartId id);

    Cart Save(Cart cart);

    void Delete(CartId id);
}
