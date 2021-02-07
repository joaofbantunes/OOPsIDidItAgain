namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain
{
    public class Item
    {
        private Item(ItemId id)
        {
            Id = id;
        }
        
        public ItemId Id { get; }

        public static Item New() => new(ItemId.New());
        
        public static Item From(ItemId itemId)
            => new Item(itemId);
    }
}