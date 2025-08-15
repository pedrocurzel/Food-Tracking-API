using System;

namespace Food_Tracking_API.DTOs;

public class DiaryDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
}
