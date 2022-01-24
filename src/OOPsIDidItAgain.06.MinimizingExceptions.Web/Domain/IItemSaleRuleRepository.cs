using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.ItemSaleRule;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

public interface IItemSaleRuleRepository
{
    IItemSaleRule GetForItem(ItemId itemId);
}
