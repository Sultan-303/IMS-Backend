using IMS.DTO;
using IMS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemsController> _logger;

        public ItemsController(IItemService itemService, ILogger<ItemsController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                _logger.LogInformation("Fetching all items");
                var items = await _itemService.GetAllItemsAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllItems: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching item with ID: {id}");
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetItemById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            if (item == null)
            {
                return new BadRequestObjectResult("Item is null.");
            }

            try
            {
                _logger.LogInformation("Adding new item");
                await _itemService.AddItemAsync(item);
                return CreatedAtAction(nameof(GetItemById), new { id = item.ItemID }, item);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning($"Validation error in AddItem: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning($"Duplicate item error in AddItem: {ex.Message}");
                return Conflict(ex.Message); // Return 409 Conflict with the error message
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddItem: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Item cannot be null.");
            }

            if (id != item.ItemID)
            {
                return BadRequest("Item ID mismatch.");
            }

            try
            {
                _logger.LogInformation($"Updating item with ID: {id}");
                var existingItem = await _itemService.GetItemByIdAsync(id);
                if (existingItem == null)
                {
                    return NotFound();
                }

                await _itemService.UpdateItemAsync(item);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning($"Validation error in UpdateItem: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateItem: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting item with ID: {id}");
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                await _itemService.DeleteItemAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteItem: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}