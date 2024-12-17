namespace IMS.Common.DTOs.Auth
{
    public class AdminUserDTO : UserDTO
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }
    }
}