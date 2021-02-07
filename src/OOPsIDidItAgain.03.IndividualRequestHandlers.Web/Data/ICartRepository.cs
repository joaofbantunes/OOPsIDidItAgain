using System;

namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Data
{
    public interface ICartRepository
    {
        Cart Get(Guid id);
        
        Cart Save(Cart cart);

        void Delete(Guid id);
    }
}