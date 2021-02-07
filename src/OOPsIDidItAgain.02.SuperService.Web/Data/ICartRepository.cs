using System;

namespace OOPsIDidItAgain._02.SuperService.Web.Data
{
    public interface ICartRepository
    {
        Cart Get(Guid id);
        
        Cart Save(Cart cart);

        void Delete(Guid id);
    }
}