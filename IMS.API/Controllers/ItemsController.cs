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

        private const string InternalServerError = "Internal server error";

        public ItemsController(IItemService itemService, ILogger<ItemsController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            _logger.LogInformation("Fetching all items");
            try
            {
                var items = await _itemService.GetAllItemsAsync();
                _logger.LogInformation("Successfully fetched all items");
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all items");
                return StatusCode(500, InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            _logger.LogInformation("Fetching item with ID: {ItemId}", id);
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null)
                {
                    _logger.LogWarning("Item with ID: {ItemId} not found", id);
                    return NotFound();
                }
                _logger.LogInformation("Successfully fetched item with ID: {ItemId}", id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching item with ID: {ItemId}", id);
                return StatusCode(500, InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            if (item == null)
            {
                _logger.LogWarning("AddItem called with null item");
                return BadRequest("Item is null.");
            }

            _logger.LogInformation("Adding new item: {ItemName}", item.ItemName);
            try
            {
                await _itemService.AddItemAsync(item);
                _logger.LogInformation("Successfully added item: {ItemName}", item.ItemName);
                return CreatedAtAction(nameof(GetItemById), new { id = item.ItemID }, item);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Validation error in AddItem: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Duplicate item error in AddItem: {Message}", ex.Message);
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding item: {ItemName}", item.ItemName);
                return StatusCode(500, InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] Item item)
        {
            if (item == null)
            {
                _logger.LogWarning("UpdateItem called with null item");
                return BadRequest("Item cannot be null.");
            }

            if (id != item.ItemID)
            {
                _logger.LogWarning("UpdateItem called with mismatched item ID: {ItemId}", id);
                return BadRequest("Item ID mismatch.");
            }

            _logger.LogInformation("Updating item with ID: {ItemId}", id);
            try
            {
                var existingItem = await _itemService.GetItemByIdAsync(id);
                if (existingItem == null)
                {
                    _logger.LogWarning("Item with ID: {ItemId} not found for update", id);
                    return NotFound();
                }

                await _itemService.UpdateItemAsync(item);
                _logger.LogInformation("Successfully updated item with ID: {ItemId}", id);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Validation error in UpdateItem: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating item with ID: {ItemId}", id);
                return StatusCode(500, InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            _logger.LogInformation("Deleting item with ID: {ItemId}", id);
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null)
                {
                    _logger.LogWarning("Item with ID: {ItemId} not found for deletion", id);
                    return NotFound();
                }

                // Check for related records in the Stocks table
                var hasRelatedStocks = await _itemService.HasRelatedStocksAsync(id);
                if (hasRelatedStocks)
                {
                    _logger.LogWarning("Cannot delete item with ID: {ItemId} because there are related records in the Stocks table", id);
                    return Conflict(new { message = "Cannot delete item because there are related records in the Stocks table.", canForceDelete = true });
                }

                await _itemService.DeleteItemAsync(id);
                _logger.LogInformation("Successfully deleted item with ID: {ItemId}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting item with ID: {ItemId}", id);
                return StatusCode(500, InternalServerError);
            }
        }

        [HttpDelete("{id}/force")]
        public async Task<IActionResult> ForceDeleteItem(int id)
        {
            _logger.LogInformation("Force deleting item with ID: {ItemId}", id);
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null)
                {
                    _logger.LogWarning("Item with ID: {ItemId} not found for force deletion", id);
                    return NotFound();
                }

                // Delete related records in the Stocks table
                await _itemService.DeleteRelatedStocksAsync(id);

                // Delete the item
                await _itemService.DeleteItemAsync(id);
                _logger.LogInformation("Successfully force deleted item with ID: {ItemId}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while force deleting item with ID: {ItemId}", id);
                return StatusCode(500, InternalServerError);
            }
        }
    }
}