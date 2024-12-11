using IMS.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using IMS.Common.Models;

namespace IMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly ILogger<CategoriesController> _logger;

        private const string InternalServerError = "Internal Server Error";

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
                _logger.LogError(ex, "Error in GetAllCategories");
                return StatusCode(500, InternalServerError);
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
                _logger.LogError(ex, "Error in GetCategoryById");
                return StatusCode(500, InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryModel category)
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
                _logger.LogError(ex, "Error in AddCategory");
                return StatusCode(500, InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryModel category)
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
                _logger.LogError(ex, "Error in UpdateCategory");
                return StatusCode(500, InternalServerError);
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
                _logger.LogError(ex, "Error in DeleteCategory");
                return StatusCode(500, InternalServerError);
            }
        }
    }
}