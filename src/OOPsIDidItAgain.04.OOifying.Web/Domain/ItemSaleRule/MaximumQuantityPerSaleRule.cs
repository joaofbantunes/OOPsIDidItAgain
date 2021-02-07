using OOPsIDidItAgain._04.OOifying.Web.Exceptions;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain.ItemSaleRule
{
    public class MaximumQuantityPerSaleRule : IItemSaleRule
    {
        public MaximumQuantityPerSaleRule(int maximumQuantityPerSale)
        {
            MaximumQuantityPerSale = maximumQuantityPerSale;
        }

        public int MaximumQuantityPerSale { get; }
        
        public void Validate(Cart cart, Item item, int quantity)
        {
            if (MaximumQuantityPerSale < quantity)
            {
                throw new ValidationException("Quantity not allowed");
            }
        }
    }
}