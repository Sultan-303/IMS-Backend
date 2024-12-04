using IMS.DTO;
using IMS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems([FromQuery] string sortBy, [FromQuery] string filter, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var items = await _itemService.GetAllItemsAsync();
            // Apply sorting, filtering, and pagination logic here
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Item is null.");
            }

            await _itemService.AddItemAsync(item);
            return CreatedAtAction(nameof(GetItemById), new { id = item.ItemID }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] Item item)
        {
            if (item == null || item.ItemID != id)
            {
                return BadRequest("Item is null or ID mismatch.");
            }

            var existingItem = await _itemService.GetItemByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            await _itemService.UpdateItemAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            await _itemService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}