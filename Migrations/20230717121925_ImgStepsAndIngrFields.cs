using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesBook.Migrations
{
    /// <inheritdoc />
    public partial class ImgStepsAndIngrFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "RecipeBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Steps",
                table: "RecipeBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "RecipeBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "RecipeBook");

            migrationBuilder.DropColumn(
                name: "Steps",
                table: "RecipeBook");

            migrationBuilder.DropColumn(
                name: "image",
                table: "RecipeBook");
        }
    }
}
