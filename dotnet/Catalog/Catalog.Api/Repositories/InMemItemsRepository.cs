using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Api.Models;

namespace Catalog.Api.Repositories
{
	public interface IItemsRepository
	{
		Task<Item> GetItemAsync(Guid id);
		Task<IEnumerable<Item>> GetItemsAsync();
		Task CreateItemAsync(Item item);
		Task UpdateItemAsync(Item item);
		Task DeleteItemAsync(Guid item);
	}

	public class InMemItemsRepository : IItemsRepository
	{
		private readonly List<Item> _items = new()
		{
			new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, Created = DateTimeOffset.UtcNow },
			new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 12, Created = DateTimeOffset.UtcNow },
			new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 20, Created = DateTimeOffset.UtcNow },
		};

		public async Task<IEnumerable<Item>> GetItemsAsync()
		{
			return await Task.FromResult(_items);
		}

		public async Task<Item> GetItemAsync(Guid id)
		{
			var item = _items.FirstOrDefault(x => x.Id == id);
			return await Task.FromResult(item);
		}

		public async Task CreateItemAsync(Item item)
		{
			_items.Add(item);
			await Task.CompletedTask;
		}

		public async Task UpdateItemAsync(Item item)
		{
			var exitingItemIdx = _items.FindIndex(x => x.Id == item.Id);
			_items[exitingItemIdx] = item;
			await Task.CompletedTask;
		}

		public async Task DeleteItemAsync(Guid id)
		{
			var exitingItemIdx = _items.FindIndex(x => x.Id == id);
			_items.RemoveAt(exitingItemIdx);
			await Task.CompletedTask;
		}
	}
}