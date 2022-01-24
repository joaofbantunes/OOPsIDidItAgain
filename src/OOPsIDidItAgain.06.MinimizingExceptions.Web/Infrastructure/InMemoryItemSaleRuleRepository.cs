using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.ItemSaleRule;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Infrastructure;

public class InMemoryItemSaleRuleRepository : IItemSaleRuleRepository
{
    public IItemSaleRule GetForItem(ItemId itemId)
    {
        // cheating with the cast 😛
        var value = ((Either<Error, ItemId>.Right) ItemId.From("987", "6543210")).Value;

        return itemId.Equals(value)
            ? new MaximumQuantityPerSaleRule(2)
            : new NoopItemSaleRule();
    }
}