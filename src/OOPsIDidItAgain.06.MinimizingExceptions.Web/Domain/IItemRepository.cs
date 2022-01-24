namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

public interface IItemRepository
{
    Item? Get(ItemId itemId);
}
