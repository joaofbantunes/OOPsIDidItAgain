using OOPsIDidItAgain._04.OOifying.Web.Domain.ItemSaleRule;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain;

public interface IItemSaleRuleRepository
{
    IItemSaleRule GetForItem(string itemId);
}
