namespace IMS.BLL.DTOs.Auth
{
    public class AdminUserDTO : UserDTO
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }
    }
}