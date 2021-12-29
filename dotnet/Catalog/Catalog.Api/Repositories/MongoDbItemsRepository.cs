using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Api.Repositories
{
	public class MongoDbItemsRepository : IItemsRepository
	{
		private const string DatabaseName = "catalog";
		private const string CollectionName = "items";
		private readonly FilterDefinitionBuilder<Item> _filterDefinitionBuilder = Builders<Item>.Filter;
		private readonly IMongoCollection<Item> _itemsCollection;

		public MongoDbItemsRepository(IMongoClient mongoClient)
		{
			IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
			_itemsCollection = database.GetCollection<Item>(CollectionName);
		}

		public async Task<Item> GetItemAsync(Guid id)
		{
			var filter = _filterDefinitionBuilder.Eq(item => item.Id, id);
			return await _itemsCollection.Find(filter).SingleOrDefaultAsync();
		}

		public async Task<IEnumerable<Item>> GetItemsAsync()
		{
			return await _itemsCollection.Find(new BsonDocument()).ToListAsync();
		}

		public async Task CreateItemAsync(Item item)
		{
			await _itemsCollection.InsertOneAsync(item);
		}

		public async Task DeleteItemAsync(Guid id)
		{
			var filter = _filterDefinitionBuilder.Eq(existingItem => existingItem.Id, id);
			await _itemsCollection.DeleteOneAsync(filter);
		}

		public async Task UpdateItemAsync(Item item)
		{
			var filter = _filterDefinitionBuilder.Eq(existingItem => existingItem.Id, item.Id);
			await _itemsCollection.ReplaceOneAsync(filter, item);
		}
	}
}