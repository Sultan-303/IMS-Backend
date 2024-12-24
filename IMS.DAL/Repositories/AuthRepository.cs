using IMS.Common.Entities;
using IMS.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IMS.DAL.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMSContext _context;

        public AuthRepository(IMSContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> CreateAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty", nameof(username));

            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty", nameof(username));

            return await _context.Users
                .AnyAsync(u => u.Username == username);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty", nameof(email));

            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
          {
        return await _context.Users.ToListAsync();
         }

         public async Task DeleteAsync(int id)
         {
        var user = await GetByIdAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
          }

        public async Task UpdateAsync(User user)
        {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(string searchTerm, string role, bool? isActive)
        {
        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(u => 
                u.Username.Contains(searchTerm) || 
                u.Email.Contains(searchTerm));
        }

        if (!string.IsNullOrWhiteSpace(role))
        {
            query = query.Where(u => u.Role == role);
        }

        if (isActive.HasValue)
        {
            query = query.Where(u => u.IsActive == isActive.Value);
        }

        return await query.ToListAsync();
        }
    }
}