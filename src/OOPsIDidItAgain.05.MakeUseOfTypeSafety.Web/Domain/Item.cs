namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain
{
    public class Item
    {
        public Item()
        {
            Id = ItemId.New();
        }
        
        public ItemId Id { get; }
    }
}