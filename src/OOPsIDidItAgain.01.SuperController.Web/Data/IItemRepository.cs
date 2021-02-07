using System;

namespace OOPsIDidItAgain._01.SuperController.Web.Data
{
    public interface IItemRepository
    {
        Item Get(Guid itemId);
    }
}