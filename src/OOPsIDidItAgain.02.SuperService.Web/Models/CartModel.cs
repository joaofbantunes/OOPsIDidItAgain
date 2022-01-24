namespace OOPsIDidItAgain._02.SuperService.Web.Models;

public class CartModel
{
    public string Id { get; set; }

    public IEnumerable<CartItemModel> Items { get; set; }
}