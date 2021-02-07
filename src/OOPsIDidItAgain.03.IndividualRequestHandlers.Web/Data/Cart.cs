using System;
using System.Collections.Generic;

namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Data
{
    public class Cart
    {
        public Guid Id { get; set; }

        public IEnumerable<CartItem> Items { get; set; }
    }
}