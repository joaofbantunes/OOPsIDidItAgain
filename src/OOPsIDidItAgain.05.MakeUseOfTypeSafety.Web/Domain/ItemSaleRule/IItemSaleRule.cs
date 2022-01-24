namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain.ItemSaleRule;

public interface IItemSaleRule
{
    void Validate(Cart cart, Item item, int quantity);
}
