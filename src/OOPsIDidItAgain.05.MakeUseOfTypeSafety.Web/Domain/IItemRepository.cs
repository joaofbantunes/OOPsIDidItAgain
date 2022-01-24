namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

public interface IItemRepository
{
    Item? Get(ItemId itemId);
}
