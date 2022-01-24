namespace OOPsIDidItAgain._01.SuperController.Web.Models;

public record CartModel
{
    public string Id { get; set; }

    public IEnumerable<CartItemModel> Items { get; set; }
}