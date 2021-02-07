using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain
{
    public interface ICartRepository
    {
        Maybe<Cart> Get(CartId id);
        
        Cart Save(Cart cart);

        void Delete(CartId id);
    }
}