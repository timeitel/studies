using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Catalog.Models;

namespace Catalog.Repositories
{
    public class ItemsRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "Potion", Price = 9, Created = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Iron Sword", Price = 12, Created = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 20, Created = DateTimeOffset.UtcNow},
        };

        public IEnumerable<Item> GetItems()
        {
            return _items;
        }
        
        public Item GetItem(Guid id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }
    }
}