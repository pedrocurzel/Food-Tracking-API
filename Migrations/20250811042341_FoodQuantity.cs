using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Tracking_API.Migrations
{
    /// <inheritdoc />
    public partial class FoodQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodGramsQuantity",
                table: "DiaryFoods",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodGramsQuantity",
                table: "DiaryFoods");
        }
    }
}
