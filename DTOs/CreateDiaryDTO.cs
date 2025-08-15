using System;
using System.ComponentModel.DataAnnotations;

namespace Food_Tracking_API.DTOs;

public class CreateDiaryDTO
{
    [Required]
    public required int UserId { get; set; }
    [Required]
    public required DateTime Date { get; set; }
}
