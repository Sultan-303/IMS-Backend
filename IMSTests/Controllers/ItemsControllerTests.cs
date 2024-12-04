using IMS.API.Controllers;
using IMS.DTO;
using IMS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IMSTests.Controllers
{
    public class ItemsControllerTests
    {
        private readonly Mock<IItemService> _mockItemService;
        private readonly Mock<ILogger<ItemsController>> _mockLogger;
        private readonly ItemsController _itemsController;

        public ItemsControllerTests()
        {
            _mockItemService = new Mock<IItemService>();
            _mockLogger = new Mock<ILogger<ItemsController>>();
            _itemsController = new ItemsController(_mockItemService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllItems_ReturnsOkResult_WithListOfItems()
        {
            // Arrange
            var items = new List<Item> { new Item { ItemName = "Item1" }, new Item { ItemName = "Item2" } };
            _mockItemService.Setup(service => service.GetAllItemsAsync()).ReturnsAsync(items);

            // Act
            var result = await _itemsController.GetAllItems();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Item>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetItemById_ReturnsOkResult_WithItem()
        {
            // Arrange
            var item = new Item { ItemID = 1, ItemName = "Item1" };
            _mockItemService.Setup(service => service.GetItemByIdAsync(1)).ReturnsAsync(item);

            // Act
            var result = await _itemsController.GetItemById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Item>(okResult.Value);
            Assert.Equal(1, returnValue.ItemID);
        }

        [Fact]
        public async Task GetItemById_ReturnsNotFoundResult_WhenItemNotFound()
        {
            // Arrange
            _mockItemService.Setup(service => service.GetItemByIdAsync(1)).ReturnsAsync((Item)null);

            // Act
            var result = await _itemsController.GetItemById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddItem_ReturnsCreatedAtActionResult_WithItem()
        {
            // Arrange
            var item = new Item { ItemID = 1, ItemName = "NewItem" };

            // Act
            var result = await _itemsController.AddItem(item);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<Item>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.ItemID);
        }

        [Fact]
        public async Task AddItem_ReturnsBadRequest_WhenItemIsNull()
        {
            // Act
            var result = await _itemsController.AddItem(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateItem_ReturnsNoContentResult()
        {
            // Arrange
            var item = new Item { ItemID = 1, ItemName = "UpdatedItem" };
            _mockItemService.Setup(service => service.GetItemByIdAsync(1)).ReturnsAsync(item);

            // Act
            var result = await _itemsController.UpdateItem(1, item);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateItem_ReturnsBadRequest_WhenItemIsNullOrIdMismatch()
        {
            // Act
            var result = await _itemsController.UpdateItem(1, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);

            // Act
            var item = new Item { ItemID = 2, ItemName = "UpdatedItem" };
            result = await _itemsController.UpdateItem(1, item);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateItem_ReturnsNotFoundResult_WhenItemNotFound()
        {
            // Arrange
            var item = new Item { ItemID = 1, ItemName = "UpdatedItem" };
            _mockItemService.Setup(service => service.GetItemByIdAsync(1)).ReturnsAsync((Item)null);

            // Act
            var result = await _itemsController.UpdateItem(1, item);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteItem_ReturnsNoContentResult()
        {
            // Arrange
            var item = new Item { ItemID = 1, ItemName = "ItemToDelete" };
            _mockItemService.Setup(service => service.GetItemByIdAsync(1)).ReturnsAsync(item);

            // Act
            var result = await _itemsController.DeleteItem(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteItem_ReturnsNotFoundResult_WhenItemNotFound()
        {
            // Arrange
            _mockItemService.Setup(service => service.GetItemByIdAsync(1)).ReturnsAsync((Item)null);

            // Act
            var result = await _itemsController.DeleteItem(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}