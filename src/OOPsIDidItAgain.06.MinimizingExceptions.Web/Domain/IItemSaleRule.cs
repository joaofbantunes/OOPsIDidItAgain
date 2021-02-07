using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain
{
    public interface IItemSaleRule
    {
        Either<Error, Unit> Validate(Cart cart, Item item, int quantity);
    }
}