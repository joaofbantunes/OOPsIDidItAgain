using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Infrastructure;

public class InMemoryItemRepository : IItemRepository
{
    private readonly List<Item> _items = new()
    {
        Item.From(((Either<Error, ItemId>.Right) ItemId.From("987", "6543210")).Value),
        Item.From(((Either<Error, ItemId>.Right) ItemId.From("123", "4567890")).Value)
    };

    public Item? Get(ItemId itemId)
        => _items.FirstOrDefault(i => i.Id.Equals(itemId));
}