using IMS.BLL.DTOs.Inventory;
using IMS.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // Helper method to retrieve user ID from claims
        private bool TryGetUserId(out int userId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim != null && int.TryParse(userIdClaim, out userId))
            {
                return true;
            }
            userId = 0;
            return false;
        }

        // Item Endpoints

        [HttpGet("items")]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetUserItems()
        {
            if (!TryGetUserId(out int userId))
                return Unauthorized();

            var items = await _inventoryService.GetUserItemsAsync(userId);
            return Ok(items);
        }

        [HttpPost("items")]
        public async Task<ActionResult<ItemDTO>> AddItem([FromBody] ItemDTO itemDto)
        {
            if (!TryGetUserId(out int userId))
                return Unauthorized();

            var newItem = await _inventoryService.AddItemAsync(userId, itemDto);
            return CreatedAtAction(nameof(GetUserItems), new { id = newItem.Id }, newItem);
        }

        [HttpPut("items/{id}")]
        public async Task<ActionResult<ItemDTO>> UpdateItem(int id, [FromBody] UpdateItemDTO updateItemDto)
        {
            if (id != updateItemDto.Id)
                return BadRequest("Item ID mismatch.");

            var updatedItem = await _inventoryService.UpdateItemAsync(id, updateItemDto);
            if (updatedItem == null)
                return NotFound();

            return Ok(updatedItem);
        }

        [HttpDelete("items/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _inventoryService.DeleteItemAsync(id);
            return NoContent();
        }

        // Stock Endpoints

        [HttpGet("stocks/{itemId}")]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetItemStocks(int itemId)
        {
            if (!TryGetUserId(out int userId))
                return Unauthorized();

            var stocks = await _inventoryService.GetItemStocksAsync(itemId);
            return Ok(stocks);
        }

        [HttpGet("user-stocks")]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetUserStocks()
        {
            if (!TryGetUserId(out int userId))
                return Unauthorized();

            var stocks = await _inventoryService.GetUserStocksAsync(userId);
            return Ok(stocks);
        }

        [HttpPost("stocks")]
        public async Task<ActionResult<StockDTO>> AddStock([FromBody] StockDTO stockDto)
        {
            if (!TryGetUserId(out int userId))
                return Unauthorized();

            stockDto.UserId = userId; // Set UserId
            var newStock = await _inventoryService.AddStockAsync(stockDto);
            return CreatedAtAction(nameof(GetUserStocks), new { userId = newStock.UserId }, newStock);
        }

        [HttpPut("stocks/{id}")]
        public async Task<ActionResult<StockDTO>> UpdateStock(int id, [FromBody] UpdateStockDTO updateStockDTO)
        {
            if (!TryGetUserId(out int userId))
                return Unauthorized();

            updateStockDTO.UserId = userId; // Ensure UserId consistency
            var updatedStock = await _inventoryService.UpdateStockAsync(id, updateStockDTO);
            if (updatedStock == null)
                return NotFound();

            return Ok(updatedStock);
        }

        [HttpDelete("stocks/{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await _inventoryService.DeleteStockAsync(id);
            return NoContent();
        }

        // Category Endpoints

        /// <summary>
        /// Retrieves all categories for the authenticated user.
        /// </summary>
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            if (!TryGetUserId(out int userId))
                return Unauthorized();

            var categories = await _inventoryService.GetCategoriesByUserIdAsync(userId);
            return Ok(categories);
        }

        [HttpPost("categories")]
public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] CreateCategoryDTO request)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    if (!TryGetUserId(out int userId))
        return Unauthorized();

    var newCategory = await _inventoryService.CreateCategoryAsync(userId, request.CategoryName);
    if (newCategory == null)
        return BadRequest("Category already exists.");

    return CreatedAtAction(nameof(GetCategories), new { id = newCategory.Id }, newCategory);
}

        [HttpPost("items/{itemId}/assign-category")]
        public async Task<IActionResult> AssignCategoryToItem(int itemId, [FromBody] int categoryId)
        {
            if (!TryGetUserId(out int userId))
                return Unauthorized();

            var success = await _inventoryService.AssignCategoryToItemAsync(userId, itemId, categoryId);
            if (!success)
                return BadRequest("Failed to assign category to item. Ensure that the category and item exist and belong to the user.");

            return Ok("Category assigned to item successfully.");
        }

        [HttpPost("items/{itemId}/assign-new-category")]
        public async Task<IActionResult> AssignNewCategoryToItem(int itemId, [FromBody] string categoryName)
        {
            if (!TryGetUserId(out int userId))
                return Unauthorized();

            var success = await _inventoryService.AssignNewCategoryToItemAsync(userId, itemId, categoryName);
            if (!success)
                return BadRequest("Failed to create and assign category to item. Ensure that the item belongs to the user.");

            return Ok("New category created and assigned to item successfully.");
        }
    }
}