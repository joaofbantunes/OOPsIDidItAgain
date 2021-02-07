using System;
using System.Collections.Generic;
using System.Linq;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Infrastructure
{
    public class InMemoryItemRepository : IItemRepository
    {
        private readonly List<Item> _items = new List<Item>()
        {
            Item.From(new ItemId(Guid.Parse("2f823b5c-f93e-431e-a64c-a59f407d236f"))),
            Item.From(new ItemId(Guid.Parse("7b81a32b-67e6-4a17-a3e2-2553a5a58d34")))
        };

        public Item? Get(ItemId itemId)
            => _items.FirstOrDefault(i => i.Id.Equals(itemId));
    }
}