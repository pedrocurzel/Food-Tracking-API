using System.ComponentModel.DataAnnotations;

namespace Food_Tracking_API.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required, EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public byte[] PasswordHash { get; set; }
    
    [Required]
    public byte[] PasswordSalt { get; set; }

    public ICollection<Diary> Diaries { get; set; } = new List<Diary>();
}