using System;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain
{
    public interface ICartRepository
    {
        Cart Get(Guid id);
        
        Cart Save(Cart cart);

        void Delete(Guid id);
    }
}