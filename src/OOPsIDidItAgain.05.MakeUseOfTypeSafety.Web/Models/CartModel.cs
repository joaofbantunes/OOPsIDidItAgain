using System.Collections.Generic;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Models
{
    public record CartModel(CartId Id, IEnumerable<CartItemModel> Items);
}
