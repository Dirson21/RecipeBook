using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBookBackend.Migrations
{
    public partial class RecipeBook1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_UserAccountId",
                table: "Recipe");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_UserAccountId",
                table: "Recipe",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_UserAccountId",
                table: "Recipe");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_UserAccountId",
                table: "Recipe",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
