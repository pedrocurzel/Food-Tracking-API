using Food_Tracking_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracking_API.Context;

public class FoodTrackingContext(DbContextOptions opts) : DbContext(opts)
{
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Diary> Diaries { get; set; } = null!;
    public DbSet<Food> Foods { get; set; } = null!;
    public DbSet<DiaryFood> DiaryFoods { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Example seed for Foods
        modelBuilder.Entity<Food>().HasData(
            new Food { Id = 1, Name = "Cooked Rice (White)", Calories = 130, Protein = 2.7, Carbohydrates = 28.7, Fats = 0.3 },
            new Food { Id = 2, Name = "Cooked Beans (Black)", Calories = 127, Protein = 8.1, Carbohydrates = 22.8, Fats = 0.5 },
            new Food { Id = 3, Name = "Cooked Chicken Breast (Skinless)", Calories = 165, Protein = 31.0, Carbohydrates = 0, Fats = 3.6 },
            new Food { Id = 4, Name = "Pure Peanut Butter (No Sugar, Natural)", Calories = 588, Protein = 25.0, Carbohydrates = 20.0, Fats = 50.0 },
            new Food { Id = 5, Name = "Integral Medica Whey Protein (Unflavored)", Calories = 370, Protein = 75.0, Carbohydrates = 8.0, Fats = 6.0 },
            new Food { Id = 6, Name = "Bread (White)", Calories = 265, Protein = 9.0, Carbohydrates = 49.0, Fats = 3.5 },
            new Food { Id = 7, Name = "Whole Wheat Bread", Calories = 247, Protein = 12.0, Carbohydrates = 41.0, Fats = 3.5 },
            new Food { Id = 8, Name = "Cooked Pasta (Whole Wheat)", Calories = 131, Protein = 5.0, Carbohydrates = 25.0, Fats = 1.1 },
            new Food { Id = 9, Name = "Olive Oil (Extra Virgin)", Calories = 884, Protein = 0, Carbohydrates = 0, Fats = 100 }
        );
    }
}