using System;
using System.Collections.Generic;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain.ItemSaleRule
{
    public class CompositeItemSaleRule : IItemSaleRule
    {
        private readonly IEnumerable<IItemSaleRule> _rules;

        public CompositeItemSaleRule(IEnumerable<IItemSaleRule> rules)
        {
            _rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }
        
        public void Validate(Cart cart, Item item, int quantity)
        {
            foreach (var rule in _rules)
            {
                rule.Validate(cart, item, quantity);
            }
        }
    }
}