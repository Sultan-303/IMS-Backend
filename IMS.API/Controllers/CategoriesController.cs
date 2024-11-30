using IMS.DTO;
using IMS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase{
        private readonly ICategoriesService _categoriesService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoriesService categoriesService, ILogger<CategoriesController> logger){
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
                _logger.LogError($"Error in GetCategories: {ex.Message}");	
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}