namespace IMS.Common.DTOs.Auth
{
    public class UpdateUserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  // Plain text for updates
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}