using System;
using System.ComponentModel.DataAnnotations;
using Food_Tracking_API.Structs;

namespace Food_Tracking_API.DTOs;

public class DiaryFoodDTO
{
    public int Id { get; set; }
    [Required]
    public required int DiaryId { get; set; }
    [Required]
    public required int FoodId { get; set; }
    [Required]
    public required int FoodGramsQuantity { get; set; }
    [Required, Range(0, 3)]
    public required MealCategory MealCategory { get; set; }
}
