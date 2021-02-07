using System.Collections.Generic;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Models
{
    public record CartModel(CartId Id, IEnumerable<CartItemModel> Items);
}
