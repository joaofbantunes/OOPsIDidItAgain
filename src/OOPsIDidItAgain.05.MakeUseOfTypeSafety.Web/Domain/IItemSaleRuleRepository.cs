namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain
{
    public interface IItemSaleRuleRepository
    {
        IItemSaleRule GetForItem(ItemId itemId);
    }
}