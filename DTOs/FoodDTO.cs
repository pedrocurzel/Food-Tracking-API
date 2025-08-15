using System;

namespace Food_Tracking_API.DTOs;

public class FoodDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Protein { get; set; } //100g 
    public double Carbohydrates { get; set; } //100g 
    public double Fats { get; set; } //100g 
    public int Calories { get; set; } //100g
}
