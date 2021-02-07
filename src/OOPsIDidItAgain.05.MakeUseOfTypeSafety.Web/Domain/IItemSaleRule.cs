namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain
{
    public interface IItemSaleRule
    {
        void Validate(Cart cart, Item item, int quantity);
    }
}