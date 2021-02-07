using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Models
{
    public class AddItemToCartModel
    {
        public ItemId ItemId { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
