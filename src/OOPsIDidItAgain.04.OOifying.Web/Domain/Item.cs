namespace OOPsIDidItAgain._04.OOifying.Web.Domain;

public class Item
{
    public Item()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; }
}
