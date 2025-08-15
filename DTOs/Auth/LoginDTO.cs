using System;
using System.ComponentModel.DataAnnotations;

namespace Food_Tracking_API.DTOs.Auth;

public class LoginDTO
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;

}
