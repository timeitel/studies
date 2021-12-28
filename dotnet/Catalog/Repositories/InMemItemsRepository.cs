using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Models;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid item);
    }

    public class InMemItemsRepository : IItemsRepository
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

        public void CreateItem(Item item)
        {
            _items.Add(item);
        }
        
        public void UpdateItem(Item item)
        {
            var exitingItemIdx = _items.FindIndex(x => x.Id == item.Id);
            _items[exitingItemIdx] = item;
        }
        
        public void DeleteItem(Guid id)
        {
            var exitingItemIdx = _items.FindIndex(x => x.Id == id);
            _items.RemoveAt(exitingItemIdx);
        }
    }
}