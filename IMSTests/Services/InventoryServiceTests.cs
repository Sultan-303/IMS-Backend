using IMS.BLL.DTOs.Inventory;
using IMS.BLL.Interfaces.Repositories;
using IMS.BLL.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IMS.BLL.Tests.Services
{
    public class InventoryServiceTests
    {
        private readonly Mock<IInventoryRepository> _inventoryRepositoryMock;
        private readonly InventoryService _inventoryService;

        public InventoryServiceTests()
        {
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _inventoryService = new InventoryService(_inventoryRepositoryMock.Object);
        }

        // GetUserItemsAsync Tests
        [Fact]
        public async Task GetUserItemsAsync_ShouldReturnItems()
        {
            // Arrange
            int userId = 1;
            var items = new List<ItemDTO>
            {
                new ItemDTO { Id = 1, Name = "Item1", Unit = "pcs", Description = "Desc1", Price = 10.0m, Stock = 100 },
                new ItemDTO { Id = 2, Name = "Item2", Unit = "pcs", Description = "Desc2", Price = 20.0m, Stock = 200 }
            };
            _inventoryRepositoryMock.Setup(repo => repo.GetItemsByUserIdAsync(userId))
                                    .ReturnsAsync(items);

            // Act
            var result = await _inventoryService.GetUserItemsAsync(userId);

            // Assert
            Assert.Equal(items, result);
            _inventoryRepositoryMock.Verify(repo => repo.GetItemsByUserIdAsync(userId), Times.Once);
        }

        // AddItemAsync Tests
        [Fact]
        public async Task AddItemAsync_ShouldReturnAddedItem()
        {
            // Arrange
            int userId = 1;
            var newItem = new ItemDTO { Id = 3, Name = "Item3", Unit = "pcs", Description = "Desc3", Price = 30.0m, Stock = 300 };
            _inventoryRepositoryMock.Setup(repo => repo.AddItemAsync(userId, newItem))
                                    .ReturnsAsync(newItem);

            // Act
            var result = await _inventoryService.AddItemAsync(userId, newItem);

            // Assert
            Assert.Equal(newItem, result);
            _inventoryRepositoryMock.Verify(repo => repo.AddItemAsync(userId, newItem), Times.Once);
        }

        // UpdateItemAsync Tests
        [Fact]
        public async Task UpdateItemAsync_ShouldReturnUpdatedItem()
        {
            // Arrange
            int id = 1;
            var updateDto = new UpdateItemDTO { Id = id, Stock = 150 };
            var updatedItem = new ItemDTO { Id = id, Name = "Item1", Unit = "pcs", Description = "Desc1", Price = 10.0m, Stock = 150 };
            _inventoryRepositoryMock.Setup(repo => repo.UpdateItemAsync(id, updateDto))
                                    .ReturnsAsync(updatedItem);

            // Act
            var result = await _inventoryService.UpdateItemAsync(id, updateDto);

            // Assert
            Assert.Equal(updatedItem, result);
            _inventoryRepositoryMock.Verify(repo => repo.UpdateItemAsync(id, updateDto), Times.Once);
        }

        // DeleteItemAsync Tests
        [Fact]
        public async Task DeleteItemAsync_ShouldCallRepositoryDelete()
        {
            // Arrange
            int id = 1;
            _inventoryRepositoryMock.Setup(repo => repo.DeleteItemAsync(id))
                                    .Returns(Task.CompletedTask)
                                    .Verifiable();

            // Act
            await _inventoryService.DeleteItemAsync(id);

            // Assert
            _inventoryRepositoryMock.Verify(repo => repo.DeleteItemAsync(id), Times.Once);
        }

        // CheckAndReorderStockAsync Tests
        [Fact]
        public async Task CheckAndReorderStockAsync_ShouldReorder_WhenStockBelowThreshold()
        {
            // Arrange
            int itemId = 1;
            int reorderThreshold = 10;
            int reorderQuantity = 20;
            var item = new ItemDTO { Id = itemId, Stock = 5 };

            _inventoryRepositoryMock.Setup(repo => repo.GetItemByIdAsync(itemId))
                                    .ReturnsAsync(item);

            _inventoryRepositoryMock.Setup(repo => repo.UpdateItemAsync(itemId, It.Is<UpdateItemDTO>(dto => dto.Stock == 25)))
                                    .ReturnsAsync(new ItemDTO { Id = itemId, Stock = 25 });

            // Act
            await _inventoryService.CheckAndReorderStockAsync(itemId, reorderThreshold, reorderQuantity);

            // Assert
            _inventoryRepositoryMock.Verify(repo => repo.GetItemByIdAsync(itemId), Times.Once);
            _inventoryRepositoryMock.Verify(repo => repo.UpdateItemAsync(itemId, It.Is<UpdateItemDTO>(dto => dto.Stock == 25)), Times.Once);
        }

        [Fact]
        public async Task CheckAndReorderStockAsync_ShouldNotReorder_WhenStockAboveThreshold()
        {
            // Arrange
            int itemId = 2;
            int reorderThreshold = 10;
            int reorderQuantity = 20;
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
            int itemId = 3;
            int reorderThreshold = 10;
            int reorderQuantity = 20;

            _inventoryRepositoryMock.Setup(repo => repo.GetItemByIdAsync(itemId))
                                    .ReturnsAsync((ItemDTO)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _inventoryService.CheckAndReorderStockAsync(itemId, reorderThreshold, reorderQuantity));
            _inventoryRepositoryMock.Verify(repo => repo.GetItemByIdAsync(itemId), Times.Once);
            _inventoryRepositoryMock.Verify(repo => repo.UpdateItemAsync(It.IsAny<int>(), It.IsAny<UpdateItemDTO>()), Times.Never);
        }

        // GetItemStocksAsync Tests
        [Fact]
        public async Task GetItemStocksAsync_ShouldReturnStocks()
        {
            // Arrange
            int itemId = 1;
            var stocks = new List<StockDTO>
            {
                new StockDTO { StockID = 1, ItemID = itemId, Quantity = 50, MinimumStockQuantity = 10, UserId = 1 },
                new StockDTO { StockID = 2, ItemID = itemId, Quantity = 30, MinimumStockQuantity = 5, UserId = 1 }
            };
            _inventoryRepositoryMock.Setup(repo => repo.GetStocksByItemIdAsync(itemId))
                                    .ReturnsAsync(stocks);

            // Act
            var result = await _inventoryService.GetItemStocksAsync(itemId);

            // Assert
            Assert.Equal(stocks, result);
            _inventoryRepositoryMock.Verify(repo => repo.GetStocksByItemIdAsync(itemId), Times.Once);
        }

        // GetUserStocksAsync Tests
        [Fact]
        public async Task GetUserStocksAsync_ShouldReturnUserStocks()
        {
            // Arrange
            int userId = 1;
            var stocks = new List<StockDTO>
            {
                new StockDTO { StockID = 1, ItemID = 1, Quantity = 50, MinimumStockQuantity = 10, UserId = userId },
                new StockDTO { StockID = 2, ItemID = 2, Quantity = 30, MinimumStockQuantity = 5, UserId = userId }
            };
            _inventoryRepositoryMock.Setup(repo => repo.GetStocksByUserIdAsync(userId))
                                    .ReturnsAsync(stocks);

            // Act
            var result = await _inventoryService.GetUserStocksAsync(userId);

            // Assert
            Assert.Equal(stocks, result);
            _inventoryRepositoryMock.Verify(repo => repo.GetStocksByUserIdAsync(userId), Times.Once);
        }

        // AddStockAsync Tests
        [Fact]
        public async Task AddStockAsync_ShouldReturnAddedStock()
        {
            // Arrange
            var stockDto = new StockDTO { StockID = 3, ItemID = 1, Quantity = 20, MinimumStockQuantity = 10, UserId = 1 };
            _inventoryRepositoryMock.Setup(repo => repo.AddStockAsync(stockDto))
                                    .ReturnsAsync(stockDto);

            // Act
            var result = await _inventoryService.AddStockAsync(stockDto);

            // Assert
            Assert.Equal(stockDto, result);
            _inventoryRepositoryMock.Verify(repo => repo.AddStockAsync(stockDto), Times.Once);
        }

        // UpdateStockAsync Tests
        [Fact]
        public async Task UpdateStockAsync_ShouldReturnUpdatedStock()
        {
            // Arrange
            int id = 1;
            var updateDto = new UpdateStockDTO 
            { 
                Id = id, 
                ItemId = id, // Ensure ItemId is set
                NewQuantity = 60 
            };
            var updatedStock = new StockDTO 
            { 
                StockID = id, 
                ItemID = 1, 
                Quantity = 60, 
                MinimumStockQuantity = 10, 
                UserId = 1 
            };
            _inventoryRepositoryMock.Setup(repo => repo.UpdateStockAsync(id, updateDto))
                                    .ReturnsAsync(updatedStock);

            // Act
            var result = await _inventoryService.UpdateStockAsync(id, updateDto);

            // Assert
            Assert.Equal(updatedStock, result);
            _inventoryRepositoryMock.Verify(repo => repo.UpdateStockAsync(id, updateDto), Times.Once);
        }

        // DeleteStockAsync Tests
        [Fact]
        public async Task DeleteStockAsync_ShouldCallRepositoryDelete()
        {
            // Arrange
            int id = 1;
            _inventoryRepositoryMock.Setup(repo => repo.DeleteStockAsync(id))
                                    .Returns(Task.CompletedTask)
                                    .Verifiable();

            // Act
            await _inventoryService.DeleteStockAsync(id);

            // Assert
            _inventoryRepositoryMock.Verify(repo => repo.DeleteStockAsync(id), Times.Once);
        }

        // GetCategoriesByUserIdAsync Tests
        [Fact]
        public async Task GetCategoriesByUserIdAsync_ShouldReturnCategories()
        {
            // Arrange
            int userId = 1;
            var categories = new List<CategoryDTO>
            {
                new CategoryDTO { Id = 1, CategoryName = "Electronics", UserId = userId },
                new CategoryDTO { Id = 2, CategoryName = "Office Supplies", UserId = userId }
            };
            _inventoryRepositoryMock.Setup(repo => repo.GetCategoriesByUserIdAsync(userId))
                                    .ReturnsAsync(categories);

            // Act
            var result = await _inventoryService.GetCategoriesByUserIdAsync(userId);

            // Assert
            Assert.Equal(categories, result);
            _inventoryRepositoryMock.Verify(repo => repo.GetCategoriesByUserIdAsync(userId), Times.Once);
        }

        // CreateCategoryAsync Tests
        [Fact]
        public async Task CreateCategoryAsync_ShouldReturnCreatedCategory()
        {
            // Arrange
            int userId = 1;
            string categoryName = "Garden Supplies";
            var category = new CategoryDTO { Id = 3, CategoryName = categoryName, UserId = userId };
            _inventoryRepositoryMock.Setup(repo => repo.CreateCategoryAsync(userId, categoryName))
                                    .ReturnsAsync(category);

            // Act
            var result = await _inventoryService.CreateCategoryAsync(userId, categoryName);

            // Assert
            Assert.Equal(category, result);
            _inventoryRepositoryMock.Verify(repo => repo.CreateCategoryAsync(userId, categoryName), Times.Once);
        }

        // AssignCategoryToItemAsync Tests
        [Fact]
        public async Task AssignCategoryToItemAsync_ShouldReturnTrue_WhenAssignmentSuccessful()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            int categoryId = 2;
            _inventoryRepositoryMock.Setup(repo => repo.AssignCategoryToItemAsync(userId, itemId, categoryId))
                                    .ReturnsAsync(true);

            // Act
            var result = await _inventoryService.AssignCategoryToItemAsync(userId, itemId, categoryId);

            // Assert
            Assert.True(result);
            _inventoryRepositoryMock.Verify(repo => repo.AssignCategoryToItemAsync(userId, itemId, categoryId), Times.Once);
        }

        [Fact]
        public async Task AssignCategoryToItemAsync_ShouldReturnFalse_WhenAssignmentFails()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            int categoryId = 2;
            _inventoryRepositoryMock.Setup(repo => repo.AssignCategoryToItemAsync(userId, itemId, categoryId))
                                    .ReturnsAsync(false);

            // Act
            var result = await _inventoryService.AssignCategoryToItemAsync(userId, itemId, categoryId);

            // Assert
            Assert.False(result);
            _inventoryRepositoryMock.Verify(repo => repo.AssignCategoryToItemAsync(userId, itemId, categoryId), Times.Once);
        }

        // AssignNewCategoryToItemAsync Tests
        [Fact]
        public async Task AssignNewCategoryToItemAsync_ShouldReturnTrue_WhenAssignmentSuccessful()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            string categoryName = "Cleaning Supplies";
            _inventoryRepositoryMock.Setup(repo => repo.AssignNewCategoryToItemAsync(userId, itemId, categoryName))
                                    .ReturnsAsync(true);

            // Act
            var result = await _inventoryService.AssignNewCategoryToItemAsync(userId, itemId, categoryName);

            // Assert
            Assert.True(result);
            _inventoryRepositoryMock.Verify(repo => repo.AssignNewCategoryToItemAsync(userId, itemId, categoryName), Times.Once);
        }

        [Fact]
        public async Task AssignNewCategoryToItemAsync_ShouldReturnFalse_WhenAssignmentFails()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            string categoryName = "Cleaning Supplies";
            _inventoryRepositoryMock.Setup(repo => repo.AssignNewCategoryToItemAsync(userId, itemId, categoryName))
                                    .ReturnsAsync(false);

            // Act
            var result = await _inventoryService.AssignNewCategoryToItemAsync(userId, itemId, categoryName);

            // Assert
            Assert.False(result);
            _inventoryRepositoryMock.Verify(repo => repo.AssignNewCategoryToItemAsync(userId, itemId, categoryName), Times.Once);
        }
    }
}