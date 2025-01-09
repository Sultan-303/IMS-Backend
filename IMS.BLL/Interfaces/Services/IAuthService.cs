using IMS.BLL.DTOs.Auth;
using IMS.BLL.DTOs.Admin;

namespace IMS.BLL.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserDTO> RegisterAsync(RegisterDTO registerDto);
        Task<string> LoginAsync(LoginDTO loginDto);
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByUsernameAsync(string username);
        Task<IEnumerable<AdminUserDTO>> GetAllUsersAsync();
        Task DeleteUserAsync(int id);
        Task<UserDTO> UpdateUserAsync(int id, UpdateUserDTO updateDto);
        Task<AdminDashboardStatsDTO> GetAdminDashboardStatsAsync();
        Task<IEnumerable<UserDTO>> SearchUsersAsync(string searchTerm, string role, bool? isActive);
    }
}