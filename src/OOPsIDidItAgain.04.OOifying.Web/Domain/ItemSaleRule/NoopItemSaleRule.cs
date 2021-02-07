namespace OOPsIDidItAgain._04.OOifying.Web.Domain.ItemSaleRule
{
    public class NoopItemSaleRule : IItemSaleRule
    {
        public void Validate(Cart cart, Item item, int quantity)
        {
            // NOOP
        }
    }
}