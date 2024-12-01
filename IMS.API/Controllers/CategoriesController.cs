using IMS.DTO;
using IMS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoriesService categoriesService, ILogger<CategoriesController> logger)
        {
            _categoriesService = categoriesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoriesService.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllCategories: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoriesService.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetCategoryById: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Category is null.");
                }

                await _categoriesService.AddCategoryAsync(category);
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryID }, category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddCategory: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            try
            {
                if (category == null || category.CategoryID != id)
                {
                    return BadRequest("Category is null or ID mismatch.");
                }

                var existingCategory = await _categoriesService.GetCategoryByIdAsync(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                await _categoriesService.UpdateCategoryAsync(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateCategory: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _categoriesService.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                await _categoriesService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteCategory: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}