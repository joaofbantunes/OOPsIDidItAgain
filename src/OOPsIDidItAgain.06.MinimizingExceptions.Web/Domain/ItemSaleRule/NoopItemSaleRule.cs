using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.ItemSaleRule;

public class NoopItemSaleRule : IItemSaleRule
{
    private static readonly Either<Error, Unit> NoopResult = Either.Right<Error, Unit>(Unit.Instance);

    public Either<Error, Unit> Validate(Cart cart, Item item, int quantity) => NoopResult;
}
