using IMS.Interfaces.Services;
using IMS.Common.Models;
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
                _logger.LogInformation("Fetched {StockCount} stock items", stock.Count());
                return Ok(stock);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllStock: {Message}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById(int id)
        {
            try
            {
                _logger.LogInformation("Fetching stock with ID: {StockId}", id);
                var stock = await _stockService.GetStockByIdAsync(id);
                if (stock == null)
                {
                    _logger.LogWarning("Stock with ID {StockId} not found.", id);
                    return NotFound($"Stock with ID {id} not found.");
                }
                _logger.LogInformation("Fetched stock with ID: {StockId}", id);
                return Ok(stock);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetStockById: {Message}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] StockModel stock)
        {
            try
            {
                _logger.LogInformation("Adding new stock: {@Stock}", stock);
                await _stockService.AddStockAsync(stock);
                _logger.LogInformation("Added stock with ID: {StockID}", stock.StockID);
                return CreatedAtAction(nameof(GetStockById), new { id = stock.StockID }, stock);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Validation error in AddStock: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddStock: {Message}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] StockModel stock)
        {
            if (id != stock.StockID)
            {
                _logger.LogWarning("Stock ID mismatch: {Id} != {StockID}", id, stock.StockID);
                return BadRequest("Stock ID mismatch.");
            }

            try
            {
                _logger.LogInformation("Updating stock with ID: {StockId}", id);
                await _stockService.UpdateStockAsync(stock);
                _logger.LogInformation("Updated stock with ID: {StockId}", id);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Validation error in UpdateStock: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateStock: {Message}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            try
            {
                _logger.LogInformation("Deleting stock with ID: {StockId}", id);
                await _stockService.DeleteStockAsync(id);
                _logger.LogInformation("Deleted stock with ID: {StockId}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteStock: {Message}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}