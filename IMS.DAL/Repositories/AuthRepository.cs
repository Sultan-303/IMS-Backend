using AutoMapper;
using IMS.BLL.DTOs.Auth;
using IMS.DAL.Entities;
using IMS.BLL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IMS.DAL.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMSContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(IMSContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDTO> CreateAsync(RegisterDTO registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetByUsernameAsync(string username)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<AdminUserDTO>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<AdminUserDTO>>(users);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(UpdateUserDTO updateUserDto)
        {
            var user = await _context.Users.FindAsync(updateUserDto.Id);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {updateUserDto.Id} not found");

            _mapper.Map(updateUserDto, user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdminUserDTO>> SearchUsersAsync(string searchTerm, string role, bool? isActive)
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

            var users = await query.ToListAsync();
            return _mapper.Map<IEnumerable<AdminUserDTO>>(users);
        }
    }
}