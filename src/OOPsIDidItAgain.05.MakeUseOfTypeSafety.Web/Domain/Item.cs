namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

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
