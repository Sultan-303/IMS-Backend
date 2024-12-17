using AutoMapper;
using IMS.Common.DTOs.Auth;
using IMS.Common.Entities;
using IMS.Interfaces.Repositories;
using IMS.Interfaces.Services;
using BCrypt.Net;

namespace IMS.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public AuthService(
            IAuthRepository authRepository, 
            IMapper mapper,
            JwtService jwtService)
        {
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        }

        public async Task<UserDTO> RegisterAsync(RegisterDTO registerDto)
        {
            if (registerDto == null)
                throw new ArgumentNullException(nameof(registerDto));

            if (string.IsNullOrWhiteSpace(registerDto.Username))
                throw new ArgumentException("Username is required");

            if (string.IsNullOrWhiteSpace(registerDto.Password))
                throw new ArgumentException("Password is required");

            if (await _authRepository.UsernameExistsAsync(registerDto.Username))
                throw new InvalidOperationException("Username already exists");

            if (await _authRepository.EmailExistsAsync(registerDto.Email))
                throw new InvalidOperationException("Email already exists");

            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var createdUser = await _authRepository.CreateAsync(user);
            return _mapper.Map<UserDTO>(createdUser);
        }

        public async Task<string> LoginAsync(LoginDTO loginDto)
        {
            if (loginDto == null)
                throw new ArgumentNullException(nameof(loginDto));

            var user = await _authRepository.GetByUsernameAsync(loginDto.Username);
            if (user == null)
                throw new InvalidOperationException("Invalid username or password");

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                throw new InvalidOperationException("Invalid username or password");

            return _jwtService.GenerateToken(user.Id, user.Username, user.Role);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid user ID", nameof(id));

            var user = await _authRepository.GetByIdAsync(id);
            if (user == null)
                throw new InvalidOperationException($"User with ID {id} not found");

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required", nameof(username));

            var user = await _authRepository.GetByUsernameAsync(username);
            if (user == null)
                throw new InvalidOperationException($"User '{username}' not found");

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<AdminUserDTO>> GetAllUsersAsync()
        {
            var users = await _authRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AdminUserDTO>>(users);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _authRepository.GetByIdAsync(id);
            if (user == null)
                throw new InvalidOperationException("User not found");

            await _authRepository.DeleteAsync(id);
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UpdateUserDTO updateDto)
        {
        if (updateDto == null)
            throw new ArgumentNullException(nameof(updateDto));

        var user = await _authRepository.GetByIdAsync(id);
        if (user == null)
            throw new InvalidOperationException($"User with ID {id} not found");

        if (!string.IsNullOrWhiteSpace(updateDto.Username) && updateDto.Username != user.Username)
        {
            if (await _authRepository.UsernameExistsAsync(updateDto.Username))
                throw new InvalidOperationException("Username already exists");
            user.Username = updateDto.Username;
        }

        if (!string.IsNullOrWhiteSpace(updateDto.Email) && updateDto.Email != user.Email)
        {
            if (await _authRepository.EmailExistsAsync(updateDto.Email))
                throw new InvalidOperationException("Email already exists");
            user.Email = updateDto.Email;
        }

        if (!string.IsNullOrWhiteSpace(updateDto.Password))
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateDto.Password);

        if (!string.IsNullOrWhiteSpace(updateDto.Role))
            user.Role = updateDto.Role;

        user.IsActive = updateDto.IsActive;

        await _authRepository.UpdateAsync(user);
        return _mapper.Map<UserDTO>(user);
        }
    }
}