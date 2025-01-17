using IMS.BLL.DTOs.Inventory;
using IMS.BLL.Interfaces.Repositories;
using IMS.BLL.Services;
using Moq;
using Xunit;
using System;
using System.Threading.Tasks;

namespace IMS.BLL.Tests.Services
{
    public class InventoryServiceTests
    {
        private readonly InventoryService _inventoryService;
        private readonly Mock<IInventoryRepository> _inventoryRepositoryMock;

        public InventoryServiceTests()
        {
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _inventoryService = new InventoryService(_inventoryRepositoryMock.Object);
        }

        [Fact]
        public async Task CheckAndReorderStockAsync_ShouldReorderStock_WhenStockIsBelowThreshold()
        {
            // Arrange
            var itemId = 1;
            var reorderThreshold = 10;
            var reorderQuantity = 20;
            var item = new ItemDTO { Id = itemId, Stock = 5 };

            _inventoryRepositoryMock.Setup(repo => repo.GetItemByIdAsync(itemId))
                                     .ReturnsAsync(item);
            _inventoryRepositoryMock.Setup(repo => repo.UpdateItemAsync(itemId, It.IsAny<UpdateItemDTO>()))
                                     .ReturnsAsync(new ItemDTO { Id = itemId, Stock = item.Stock + reorderQuantity });

            // Act
            await _inventoryService.CheckAndReorderStockAsync(itemId, reorderThreshold, reorderQuantity);

            // Assert
            _inventoryRepositoryMock.Verify(repo => repo.GetItemByIdAsync(itemId), Times.Once);
            _inventoryRepositoryMock.Verify(repo => repo.UpdateItemAsync(itemId, It.Is<UpdateItemDTO>(dto => dto.Stock == item.Stock + reorderQuantity)), Times.Once);
        }

        [Fact]
        public async Task CheckAndReorderStockAsync_ShouldNotReorderStock_WhenStockIsAboveThreshold()
        {
            // Arrange
            var itemId = 2;
            var reorderThreshold = 10;
            var reorderQuantity = 20;
            var item = new ItemDTO { Id = itemId, Stock = 15 };

            _inventoryRepositoryMock.Setup(repo => repo.GetItemByIdAsync(itemId))
                                     .ReturnsAsync(item);

            // Act
            await _inventoryService.CheckAndReorderStockAsync(itemId, reorderThreshold, reorderQuantity);

            // Assert
            _inventoryRepositoryMock.Verify(repo => repo.GetItemByIdAsync(itemId), Times.Once);
            _inventoryRepositoryMock.Verify(repo => repo.UpdateItemAsync(It.IsAny<int>(), It.IsAny<UpdateItemDTO>()), Times.Never);
        }

        [Fact]
        public async Task CheckAndReorderStockAsync_ShouldThrowException_WhenItemNotFound()
        {
            // Arrange
            var itemId = 3;
            var reorderThreshold = 10;
            var reorderQuantity = 20;

            _inventoryRepositoryMock.Setup(repo => repo.GetItemByIdAsync(itemId))
                                     .ReturnsAsync((ItemDTO)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _inventoryService.CheckAndReorderStockAsync(itemId, reorderThreshold, reorderQuantity));
        }
    }
}