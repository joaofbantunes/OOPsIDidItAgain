using System;
using System.Collections.Generic;

namespace OOPsIDidItAgain._04.OOifying.Web.Models
{
    public class CartModel
    {
        public Guid Id { get; set; }

        public IEnumerable<CartItemModel> Items { get; set; }
    }
}
