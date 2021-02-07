using System;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain
{
    public interface IItemSaleRuleRepository
    {
        IItemSaleRule GetForItem(Guid itemId);
    }
}