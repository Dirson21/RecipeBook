using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBookBackend.Migrations
{
    public partial class recipeFavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavorite_AspNetUsers_UserFavoritesId",
                table: "RecipeFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavorite_Recipe_RecipeFavoritesId",
                table: "RecipeFavorite");

            migrationBuilder.RenameColumn(
                name: "UserFavoritesId",
                table: "RecipeFavorite",
                newName: "UserAccountId");

            migrationBuilder.RenameColumn(
                name: "RecipeFavoritesId",
                table: "RecipeFavorite",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeFavorite_UserFavoritesId",
                table: "RecipeFavorite",
                newName: "IX_RecipeFavorite_UserAccountId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RecipeFavorite",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeFavorite_AspNetUsers_UserAccountId",
                table: "RecipeFavorite",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeFavorite_Recipe_RecipeId",
                table: "RecipeFavorite",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavorite_AspNetUsers_UserAccountId",
                table: "RecipeFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavorite_Recipe_RecipeId",
                table: "RecipeFavorite");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "RecipeFavorite");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "RecipeFavorite",
                newName: "UserFavoritesId");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "RecipeFavorite",
                newName: "RecipeFavoritesId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeFavorite_UserAccountId",
                table: "RecipeFavorite",
                newName: "IX_RecipeFavorite_UserFavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeFavorite_AspNetUsers_UserFavoritesId",
                table: "RecipeFavorite",
                column: "UserFavoritesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeFavorite_Recipe_RecipeFavoritesId",
                table: "RecipeFavorite",
                column: "RecipeFavoritesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
