using IMS.BLL.Services;
using IMS.DTO;
using IMS.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IMSTests.Services
{
    public class StockServiceTests
    {
        private readonly Mock<IStockRepository> _mockStockRepository;
        private readonly Mock<ILogger<StockService>> _mockLogger;
        private readonly StockService _stockService;

        public StockServiceTests()
        {
            _mockStockRepository = new Mock<IStockRepository>();
            _mockLogger = new Mock<ILogger<StockService>>();
            _stockService = new StockService(_mockStockRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllStockAsync_ReturnsAllStock()
        {
            // Arrange
            var stocks = new List<Stock> { new Stock { StockID = 1 }, new Stock { StockID = 2 } };
            _mockStockRepository.Setup(repo => repo.GetAllStockAsync()).ReturnsAsync(stocks);

            // Act
            var result = await _stockService.GetAllStockAsync();

            // Assert
            Assert.Equal(stocks, result);
        }

        [Fact]
        public async Task GetStockByIdAsync_ReturnsStock()
        {
            // Arrange
            var stock = new Stock { StockID = 1 };
            _mockStockRepository.Setup(repo => repo.GetStockByIdAsync(It.IsAny<int>())).ReturnsAsync(stock);

            // Act
            var result = await _stockService.GetStockByIdAsync(1);

            // Assert
            Assert.Equal(stock, result);
        }

        [Fact]
        public async Task AddStockAsync_AddsStock()
        {
            // Arrange
            var stock = new Stock { StockID = 1 };

            // Act
            await _stockService.AddStockAsync(stock);

            // Assert
            _mockStockRepository.Verify(repo => repo.AddStockAsync(stock), Times.Once);
        }

        [Fact]
        public async Task AddStockAsync_ThrowsException_WhenStockIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _stockService.AddStockAsync(null));
        }

        [Fact]
        public async Task UpdateStockAsync_UpdatesStock()
        {
            // Arrange
            var stock = new Stock { StockID = 1 };

            // Act
            await _stockService.UpdateStockAsync(stock);

            // Assert
            _mockStockRepository.Verify(repo => repo.UpdateStockAsync(stock), Times.Once);
        }

        [Fact]
        public async Task UpdateStockAsync_ThrowsException_WhenStockIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _stockService.UpdateStockAsync(null));
        }

        [Fact]
        public async Task DeleteStockAsync_DeletesStock()
        {
            // Arrange
            var stock = new Stock { StockID = 1 };
            _mockStockRepository.Setup(repo => repo.GetStockByIdAsync(It.IsAny<int>())).ReturnsAsync(stock);

            // Act
            await _stockService.DeleteStockAsync(1);

            // Assert
            _mockStockRepository.Verify(repo => repo.DeleteStockAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteStockAsync_DoesNothing_WhenStockNotFound()
        {
            // Arrange
            _mockStockRepository.Setup(repo => repo.GetStockByIdAsync(It.IsAny<int>())).ReturnsAsync((Stock)null);

            // Act
            await _stockService.DeleteStockAsync(1);

            // Assert
            _mockStockRepository.Verify(repo => repo.DeleteStockAsync(It.IsAny<int>()), Times.Never);
        }
    }
}