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
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly ILogger<StockController> _logger;

        public StockController(IStockService stockService, ILogger<StockController> logger)
        {
            _stockService = stockService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStock()
        {
            try
            {
                _logger.LogInformation("Fetching all stock");
                var stock = await _stockService.GetAllStockAsync();
                _logger.LogInformation($"Fetched {stock.Count()} stock items");
                return Ok(stock);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllStock: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching stock with ID: {id}");
                var stock = await _stockService.GetStockByIdAsync(id);
                if (stock == null)
                {
                    _logger.LogWarning($"Stock with ID {id} not found.");
                    return NotFound($"Stock with ID {id} not found.");
                }
                _logger.LogInformation($"Fetched stock with ID: {id}");
                return Ok(stock);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetStockById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] Stock stock)
        {
            try
            {
                _logger.LogInformation($"Adding new stock: {stock}");
                await _stockService.AddStockAsync(stock);
                _logger.LogInformation($"Added stock with ID: {stock.StockID}");
                return CreatedAtAction(nameof(GetStockById), new { id = stock.StockID }, stock);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning($"Validation error in AddStock: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddStock: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] Stock stock)
        {
            if (id != stock.StockID)
            {
                _logger.LogWarning($"Stock ID mismatch: {id} != {stock.StockID}");
                return BadRequest("Stock ID mismatch.");
            }

            try
            {
                _logger.LogInformation($"Updating stock with ID: {id}");
                await _stockService.UpdateStockAsync(stock);
                _logger.LogInformation($"Updated stock with ID: {id}");
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning($"Validation error in UpdateStock: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateStock: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting stock with ID: {id}");
                await _stockService.DeleteStockAsync(id);
                _logger.LogInformation($"Deleted stock with ID: {id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteStock: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}