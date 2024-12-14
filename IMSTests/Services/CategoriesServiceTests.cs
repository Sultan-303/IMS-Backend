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
    public class CategoriesServiceTests
    {
        private readonly Mock<ICategoriesRepository> _mockCategoriesRepository;
        private readonly CategoriesService _categoriesService;

        public CategoriesServiceTests()
        {
            _mockCategoriesRepository = new Mock<ICategoriesRepository>();
            _categoriesService = new CategoriesService(_mockCategoriesRepository.Object);
        }

        [Fact]
        public async Task GetAllCategoriesAsync_ReturnsAllCategories()
        {
            // Arrange
            var categories = new List<Category> { new Category { CategoryName = "Category1" }, new Category { CategoryName = "Category2" } };
            _mockCategoriesRepository.Setup(repo => repo.GetAllCategoriesAsync()).ReturnsAsync(categories);

            // Act
            var result = await _categoriesService.GetAllCategoriesAsync();

            // Assert
            Assert.Equal(categories, result);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ReturnsCategory()
        {
            // Arrange
            var category = new Category { CategoryName = "Category1" };
            _mockCategoriesRepository.Setup(repo => repo.GetCategoryByIdAsync(It.IsAny<int>())).ReturnsAsync(category);

            // Act
            var result = await _categoriesService.GetCategoryByIdAsync(1);

            // Assert
            Assert.Equal(category, result);
        }

        [Fact]
        public async Task AddCategoryAsync_AddsCategory()
        {
            // Arrange
            var category = new Category { CategoryName = "NewCategory" };

            // Act
            await _categoriesService.AddCategoryAsync(category);

            // Assert
            _mockCategoriesRepository.Verify(repo => repo.AddCategoryAsync(category), Times.Once);
        }

        [Fact]
        public async Task UpdateCategoryAsync_UpdatesCategory()
        {
            // Arrange
            var category = new Category { CategoryName = "UpdatedCategory" };

            // Act
            await _categoriesService.UpdateCategoryAsync(category);

            // Assert
            _mockCategoriesRepository.Verify(repo => repo.UpdateCategoryAsync(category), Times.Once);
        }

        [Fact]
        public async Task DeleteCategoryAsync_DeletesCategory()
        {
            // Arrange
            var category = new Category { CategoryID = 1 };
            _mockCategoriesRepository.Setup(repo => repo.GetCategoryByIdAsync(It.IsAny<int>())).ReturnsAsync(category);

            // Act
            await _categoriesService.DeleteCategoryAsync(1);

            // Assert
            _mockCategoriesRepository.Verify(repo => repo.DeleteCategoryAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteCategoryAsync_DoesNothing_WhenCategoryNotFound()
        {
            // Arrange
            var mockRepo = new Mock<ICategoriesRepository>();
            mockRepo.Setup(repo => repo.GetCategoryByIdAsync(It.IsAny<int>())).ReturnsAsync((Category)null);

            var service = new CategoriesService(mockRepo.Object);

            // Act
            await service.DeleteCategoryAsync(1);

            // Assert
            mockRepo.Verify(repo => repo.DeleteCategoryAsync(It.IsAny<int>()), Times.Never);
        }
    }
}