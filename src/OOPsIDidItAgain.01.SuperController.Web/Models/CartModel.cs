using System;
using System.Collections.Generic;

namespace OOPsIDidItAgain._01.SuperController.Web.Models
{
    public record CartModel
    {
        public Guid Id { get; set; }

        public IEnumerable<CartItemModel> Items { get; set; }
    }
}
