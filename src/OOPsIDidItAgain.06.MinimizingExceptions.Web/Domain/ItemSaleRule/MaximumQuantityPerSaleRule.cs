using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.ItemSaleRule;

public class MaximumQuantityPerSaleRule : IItemSaleRule
{
    public MaximumQuantityPerSaleRule(int maximumQuantityPerSale)
    {
        MaximumQuantityPerSale = maximumQuantityPerSale;
    }

    public int MaximumQuantityPerSale { get; }

    public Either<Error, Unit> Validate(Cart cart, Item item, int quantity)
        => quantity > MaximumQuantityPerSale
            ? Either.Left<Error, Unit>(new Error.Invalid("Quantity not allowed"))
            : Either.Right<Error, Unit>(Unit.Instance);

}
