namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

public class Item
{
    private Item(ItemId id)
    {
        Id = id;
    }

    public ItemId Id { get; }

    public static Item From(ItemId itemId)
        => new (itemId);
}
