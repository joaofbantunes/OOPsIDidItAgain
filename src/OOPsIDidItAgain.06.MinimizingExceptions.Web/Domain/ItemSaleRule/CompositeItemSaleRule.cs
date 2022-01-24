using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.ItemSaleRule;

public class CompositeItemSaleRule : IItemSaleRule
{
    private readonly IEnumerable<IItemSaleRule> _rules;

    public CompositeItemSaleRule(IEnumerable<IItemSaleRule> rules)
    {
        _rules = rules ?? throw new ArgumentNullException(nameof(rules));
    }

    public Either<Error, Unit> Validate(Cart cart, Item item, int quantity)
    {
        foreach (var rule in _rules)
        {
            var result = rule.Validate(cart, item, quantity);
            if (result is not Either<Error, Unit>.Right)
            {
                return result;
            }
        }

        return Either.Right<Error, Unit>(Unit.Instance);
    }
}
