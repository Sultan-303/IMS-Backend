using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IMS.Interfaces.Services;
using IMS.Common.DTOs.Auth;
using IMS.Common.DTOs.Admin;
using AutoMapper;


namespace IMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AdminController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<AdminUserDTO>>> GetAllUsers()
        {
            var users = await _authService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpDelete("users/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _authService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpPut("users/{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int id, UpdateUserDTO updateDto)
        {
            var updatedUser = await _authService.UpdateUserAsync(id, updateDto);
            return Ok(updatedUser);
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardStatsDTO>> GetDashboardStats()
        {
            var stats = await _authService.GetDashboardStatsAsync();
            return Ok(stats);
        }

        [HttpGet("users/search")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> SearchUsers(
            [FromQuery] string searchTerm,
            [FromQuery] string role,
            [FromQuery] bool? isActive)
        {
        var users = await _authService.SearchUsersAsync(searchTerm, role, isActive);
        return Ok(users);
        }
    }
}