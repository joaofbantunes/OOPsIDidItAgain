using System;

namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Data
{
    public interface IItemRepository
    {
        Item Get(Guid itemId);
    }
}