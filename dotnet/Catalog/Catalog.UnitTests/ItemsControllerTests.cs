using System;
using System.Threading.Tasks;
using Catalog.Api.Dtos;
using Catalog.Api.Models;
using Catalog.Api.Repositories;
using Catalog.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Catalog.UnitTests
{
    public class ItemsControllerTests
    {
        private readonly Mock<IItemsRepository> _repositoryStub = new();
        private readonly Mock<ILogger<ItemsController>> _loggerStub = new();
        private readonly Random _rand = new();
        [Fact]
        public async Task GetItemAsync_WithNonexistingItem_ReturnsNotFound()
        {
            // Arrange
            _repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Item) null);
            var controller = new ItemsController(_repositoryStub.Object, _loggerStub.Object);
            
            // Act
            var result = await controller.GetItemAsync(Guid.NewGuid());
            
            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
        
        [Fact]
        public async Task GetItemAsync_WithExistingItem_ReturnsExpectedItem()
        {
            // Arrange
            var expectedItem = CreateRandomItem();

            _repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedItem);
            var controller = new ItemsController(_repositoryStub.Object, _loggerStub.Object);

            // Act
            var result = await controller.GetItemAsync(Guid.NewGuid());

            // Assert
            Assert.IsType<ItemDto>(result.Value);
            var dto = ((ActionResult<ItemDto>) result).Value;
            Assert.Equal(expectedItem.Id, dto.Id);
            Assert.Equal(expectedItem.Name, dto.Name);
        }

        private Item CreateRandomItem()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Price = _rand.Next(1000),
                Created = DateTimeOffset.UtcNow
            };
        }
    }
}
