using System;
using System.ComponentModel.DataAnnotations;
using Food_Tracking_API.Structs;

namespace Food_Tracking_API.Models;

public class DiaryFood
{
    [Key]
    public int Id { get; set; }
    public MealCategory MealCategory { get; set; }

    public int FoodGramsQuantity { get; set; }

    public int FoodId { get; set; }
    public int DiaryId { get; set; }

    public Food Food { get; set; } = null!;
    public Diary Diary { get; set; } = null!;
}
