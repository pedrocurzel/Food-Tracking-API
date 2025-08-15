using System.ComponentModel.DataAnnotations;

namespace Food_Tracking_API.DTOs;

public class RegisterDTO
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}