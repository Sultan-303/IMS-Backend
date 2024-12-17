using Microsoft.AspNetCore.Mvc;
using IMS.Common.DTOs.Auth;
using IMS.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace IMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost("register")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
        {
            try
            {
                var result = await _authService.RegisterAsync(registerDto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO loginDto)
        {
            try
            {
                var token = await _authService.LoginAsync(loginDto);
                return Ok(new { token });
            }
            catch (InvalidOperationException)
            {
                return Unauthorized("Invalid username or password");
            }
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            try
            {
                var username = User.Identity?.Name;
                if (string.IsNullOrEmpty(username))
                    return Unauthorized();

                var user = await _authService.GetUserByUsernameAsync(username);
                return Ok(user);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}