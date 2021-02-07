using System;
using System.Collections.Generic;

namespace OOPsIDidItAgain._02.SuperService.Web.Models
{
    public class CartModel
    {
        public Guid Id { get; set; }

        public IEnumerable<CartItemModel> Items { get; set; }
    }
}
