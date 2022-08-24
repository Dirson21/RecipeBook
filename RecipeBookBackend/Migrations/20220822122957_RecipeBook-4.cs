using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBookBackend.Migrations
{
    public partial class RecipeBook4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientHeader_IngridientHeaderId",
                table: "Ingredient");

            migrationBuilder.RenameColumn(
                name: "IngridientHeaderId",
                table: "Ingredient",
                newName: "IngredientHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_IngridientHeaderId",
                table: "Ingredient",
                newName: "IX_Ingredient_IngredientHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientHeader_IngredientHeaderId",
                table: "Ingredient",
                column: "IngredientHeaderId",
                principalTable: "IngredientHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientHeader_IngredientHeaderId",
                table: "Ingredient");

            migrationBuilder.RenameColumn(
                name: "IngredientHeaderId",
                table: "Ingredient",
                newName: "IngridientHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_IngredientHeaderId",
                table: "Ingredient",
                newName: "IX_Ingredient_IngridientHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientHeader_IngridientHeaderId",
                table: "Ingredient",
                column: "IngridientHeaderId",
                principalTable: "IngredientHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
