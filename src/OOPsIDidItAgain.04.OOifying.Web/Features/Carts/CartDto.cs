namespace OOPsIDidItAgain._04.OOifying.Web.Features.Carts;

public class CartDto
{
    public string Id { get; set; }

    public IEnumerable<CartItemDto> Items { get; set; }
}
