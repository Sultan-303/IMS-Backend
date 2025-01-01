using IMS.BLL.DTOs.Auth;

namespace IMS.BLL.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<UserDTO> CreateAsync(RegisterDTO registerDto);
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> GetByUsernameAsync(string username);
        Task<bool> UsernameExistsAsync(string username);
        Task<bool> EmailExistsAsync(string email);
        Task<IEnumerable<AdminUserDTO>> GetAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(UpdateUserDTO updateUserDto);
        Task<IEnumerable<AdminUserDTO>> SearchUsersAsync(string searchTerm, string role, bool? isActive);
    }
}