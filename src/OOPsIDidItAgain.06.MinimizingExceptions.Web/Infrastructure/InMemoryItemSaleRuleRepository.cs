using System;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.ItemSaleRule;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Infrastructure
{
    public class InMemoryItemSaleRuleRepository : IItemSaleRuleRepository
    {
        public IItemSaleRule GetForItem(ItemId itemId)
        {
            if (itemId.Equals(new ItemId(Guid.Parse("2f823b5c-f93e-431e-a64c-a59f407d236f"))))
            {
                return new MaximumQuantityPerSaleRule(2);
            }
            else
            {
                return new NoopItemSaleRule();
            }
        }
    }
}