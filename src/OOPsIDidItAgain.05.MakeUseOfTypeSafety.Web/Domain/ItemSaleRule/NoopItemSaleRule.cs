namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain.ItemSaleRule
{
    public class NoopItemSaleRule : IItemSaleRule
    {
        public void Validate(Cart cart, Item item, int quantity)
        {
            // NOOP
        }
    }
}