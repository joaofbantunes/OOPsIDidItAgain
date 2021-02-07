using System;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain
{
    public interface IItemRepository
    {
        Item Get(Guid itemId);
    }
}