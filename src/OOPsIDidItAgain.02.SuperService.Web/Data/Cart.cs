namespace OOPsIDidItAgain._02.SuperService.Web.Data;

public class Cart
{
    public string Id { get; set; }

    public IEnumerable<CartItem> Items { get; set; }
}