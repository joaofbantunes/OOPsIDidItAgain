namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Data;

public class Cart
{
    public string Id { get; set; }

    public IEnumerable<CartItem> Items { get; set; }
}
