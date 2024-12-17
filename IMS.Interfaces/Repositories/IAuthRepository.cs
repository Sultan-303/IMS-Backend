using IMS.Common.Entities;

namespace IMS.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUsernameAsync(string username);
        Task<bool> UsernameExistsAsync(string username);
        Task<bool> EmailExistsAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(User user);
    }
}