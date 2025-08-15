using System.ComponentModel.DataAnnotations;

namespace Food_Tracking_API.Models;

public class Food
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Protein { get; set; } //100g 
    public double Carbohydrates { get; set; } //100g 
    public double Fats { get; set; } //100g 
    public int Calories { get; set; } //100g
    public List<DiaryFood> DiaryFoods { get; } = [];
}