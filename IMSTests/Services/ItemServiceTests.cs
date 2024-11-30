using IMS.BLL.Services;
using IMS.DTO;
using IMS.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IMSTests.Services
{
    public class ItemServiceTests
    {
        private readonly Mock<IItemRepository> _mockItemRepository;
        private readonly ItemService _itemService;

        public ItemServiceTests()
        {
            _mockItemRepository = new Mock<IItemRepository>();
            _itemService = new ItemService(_mockItemRepository.Object);
        }

        [Fact]
        public async Task GetAllItemsAsync_ReturnsAllItems()
        {
            // Arrange
            var items = new List<Item> { new Item { ItemName = "Item1" }, new Item { ItemName = "Item2" } };
            _mockItemRepository.Setup(repo => repo.GetAllItemsAsync()).ReturnsAsync(items);

            // Act
            var result = await _itemService.GetAllItemsAsync();

            // Assert
            Assert.Equal(items, result);
        }

        [Fact]
        public async Task GetItemByIdAsync_ReturnsItem()
        {
            // Arrange
            var item = new Item { ItemName = "Item1" };
            _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(It.IsAny<int>())).ReturnsAsync(item);

            // Act
            var result = await _itemService.GetItemByIdAsync(1);

            // Assert
            Assert.Equal(item, result);
        }

        [Fact]
        public async Task AddItemAsync_AddsItem()
        {
            // Arrange
            var item = new Item { ItemName = "NewItem" };
            _mockItemRepository.Setup(repo => repo.ItemNameExistsAsync(It.IsAny<string>())).ReturnsAsync(false);

            // Act
            await _itemService.AddItemAsync(item);

            // Assert
            _mockItemRepository.Verify(repo => repo.AddItemAsync(item), Times.Once);
        }

        [Fact]
        public async Task AddItemAsync_ThrowsException_WhenItemIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _itemService.AddItemAsync(null));
        }

        [Fact]
        public async Task AddItemAsync_ThrowsException_WhenItemNameExists()
        {
            // Arrange
            var item = new Item { ItemName = "ExistingItem" };
            _mockItemRepository.Setup(repo => repo.ItemNameExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _itemService.AddItemAsync(item));
        }

        [Fact]
        public async Task UpdateItemAsync_UpdatesItem()
        {
            // Arrange
            var item = new Item { ItemName = "UpdatedItem" };

            // Act
            await _itemService.UpdateItemAsync(item);

            // Assert
            _mockItemRepository.Verify(repo => repo.UpdateItemAsync(item), Times.Once);
        }

        [Fact]
        public async Task UpdateItemAsync_ThrowsException_WhenItemIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _itemService.UpdateItemAsync(null));
        }

        [Fact]
        public async Task DeleteItemAsync_DeletesItem()
        {
            // Arrange
            var item = new Item { ItemName = "ItemToDelete" };
            _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(It.IsAny<int>())).ReturnsAsync(item);

            // Act
            await _itemService.DeleteItemAsync(1);

            // Assert
            _mockItemRepository.Verify(repo => repo.DeleteItemAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_DoesNothing_WhenItemNotFound()
        {
            // Arrange
            _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(It.IsAny<int>())).ReturnsAsync((Item)null);

            // Act
            await _itemService.DeleteItemAsync(1);

            // Assert
            _mockItemRepository.Verify(repo => repo.DeleteItemAsync(It.IsAny<int>()), Times.Never);
        }
    }
}