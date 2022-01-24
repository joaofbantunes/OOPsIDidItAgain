namespace OOPsIDidItAgain._01.SuperController.Web.Data;

public class Cart
{
    public string Id { get; set; }

    public IEnumerable<CartItem> Items { get; set; }
}