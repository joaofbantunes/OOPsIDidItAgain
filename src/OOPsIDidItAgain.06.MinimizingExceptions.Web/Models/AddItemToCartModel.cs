using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Models
{
    public class AddItemToCartModel
    {
        public ItemId ItemId { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
