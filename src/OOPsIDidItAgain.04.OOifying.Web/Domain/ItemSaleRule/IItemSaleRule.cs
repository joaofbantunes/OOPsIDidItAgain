namespace OOPsIDidItAgain._04.OOifying.Web.Domain.ItemSaleRule;

public interface IItemSaleRule
{
    void Validate(Cart cart, Item item, int quantity);
}
