using IMS.BLL.Services;
using IMS.Common.Models;
using IMS.Common.Entities;
using IMS.Interfaces.Repositories;
using Moq;
using Xunit;
using System;
using System.Threading.Tasks;

namespace IMS.Tests.Services
{
    public class ItemServiceTests
    {
        private readonly Mock<IItemRepository> _mockRepo;
        private readonly ItemService _service;

        public ItemServiceTests()
        {
            _mockRepo = new Mock<IItemRepository>();
            _service = new ItemService(_mockRepo.Object);
        }

        [Fact]
        public async Task AddItemAsync_WhenItemNameExists_ThrowsInvalidOperationException()
        {
            // Arrange
            var itemModel = new ItemModel { ItemName = "Existing Item" };
            _mockRepo.Setup(repo => repo.ItemNameExistsAsync(itemModel.ItemName))
                    .ReturnsAsync(true);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.AddItemAsync(itemModel));
        }

        [Fact]
        public async Task AddItemAsync_WhenItemIsNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => _service.AddItemAsync(null));
        }

        [Fact]
        public async Task AddItemAsync_WhenItemNameDoesNotExist_AddsItem()
        {
            // Arrange
            var itemModel = new ItemModel { ItemName = "New Item" };
            _mockRepo.Setup(repo => repo.ItemNameExistsAsync(itemModel.ItemName))
                    .ReturnsAsync(false);

            // Act
            await _service.AddItemAsync(itemModel);

            // Assert
            _mockRepo.Verify(repo => repo.AddItemAsync(It.IsAny<Item>()), Times.Once);
        }
    }
}