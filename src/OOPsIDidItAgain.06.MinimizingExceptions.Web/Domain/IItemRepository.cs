using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain
{
    public interface IItemRepository
    {
        Item? Get(ItemId itemId);
    }
}