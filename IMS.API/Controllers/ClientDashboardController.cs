using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IMS.BLL.Interfaces.Services;
using IMS.BLL.DTOs.ClientDashboard;
using System.Security.Claims;

namespace IMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientDashboardController : ControllerBase
    {
        private readonly IClientDashboardService _dashboardService;
        private readonly ILogger<ClientDashboardController> _logger;

        public ClientDashboardController(
            IClientDashboardService dashboardService,
            ILogger<ClientDashboardController> logger)
        {
            _dashboardService = dashboardService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ClientDashboardStatsDTO>> GetDashboardStats([FromQuery] string? searchQuery = null)
        {
            try
            {
                // Retrieve UserId from JWT claims
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                {
                    return Unauthorized("Invalid user identifier.");
                }

                _logger.LogInformation("Fetching dashboard stats for User ID: {UserId} with search query: {SearchQuery}", userId, searchQuery);
                var stats = await _dashboardService.GetClientDashboardStatsAsync(userId, searchQuery);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching dashboard stats");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}