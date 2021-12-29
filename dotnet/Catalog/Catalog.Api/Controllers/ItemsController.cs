using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Api.Dtos;
using Catalog.Api.Models;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.Controllers
{
	[ApiController]
	[Route("items")]
	public class ItemsController : ControllerBase
	{
		private readonly IItemsRepository _repository;
		private readonly ILogger<ItemsController> _logger;

		public ItemsController(IItemsRepository repository, ILogger<ItemsController> logger)
		{
			_repository = repository;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IEnumerable<ItemDto>> GetItemsAsync()
		{
			var items = (await _repository
				.GetItemsAsync())
			    .Select(item => item.AsDto());

			_logger.LogInformation($"{DateTime.UtcNow:hh:mm:ss}: retrieved {items.Count()} items");
			
			return items;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
		{
			var item = await _repository.GetItemAsync(id);

			if (item == null)
			{
				return NotFound();
			}

			return item.AsDto();
		}

		[HttpPost]
		public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
		{
			Item item = new()
			{
				Id = Guid.NewGuid(),
				Name = itemDto.Name,
				Price = itemDto.Price,
				Created = DateTimeOffset.UtcNow
			};

			await _repository.CreateItemAsync(item);

			// ReSharper disable once Mvc.ActionNotResolved
			return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
		{
			var existingItem = await _repository.GetItemAsync(id);
			if (existingItem is null)
			{
				return NotFound();
			}

			var updatedItem = existingItem with
			{
				Name = itemDto.Name,
				Price = itemDto.Price
			};

			await _repository.UpdateItemAsync(updatedItem);

			return NoContent();
		}

		[HttpDelete]
		public async Task<ActionResult> DeleteItemAsync(Guid id)
		{
			var existingItem = await _repository.GetItemAsync(id);
			if (existingItem is null)
			{
				return NotFound();
			}

			await _repository.DeleteItemAsync(existingItem.Id);

			return NoContent();
		}
	}
}