using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.ItemSaleRule;

public class MinimumTimeOfDayForSaleRule : IItemSaleRule
{
    public MinimumTimeOfDayForSaleRule(TimeSpan minimumTimeOfDayForSale)
    {
        MinimumTimeOfDayForSale = minimumTimeOfDayForSale;
    }

    public TimeSpan MinimumTimeOfDayForSale { get; }

    public Either<Error, Unit> Validate(Cart cart, Item item, int quantity)
        => MinimumTimeOfDayForSale > DateTime.Now.TimeOfDay
            ? Either.Left<Error, Unit>(new Error.Invalid("Can't buy that yet!"))
            : Either.Right<Error, Unit>(Unit.Instance);
}
