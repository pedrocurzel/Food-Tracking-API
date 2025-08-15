using System.ComponentModel.DataAnnotations;

namespace Food_Tracking_API.Models;

public class Diary
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public List<DiaryFood> DiaryFoods { get; } = [];

}