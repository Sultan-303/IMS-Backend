namespace IMS.BLL.DTOs.Auth
{
    public class UserDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
}
}