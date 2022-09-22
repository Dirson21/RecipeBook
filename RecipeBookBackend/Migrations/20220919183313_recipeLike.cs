using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBookBackend.Migrations
{
    public partial class recipeLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLike_AspNetUsers_UserLikesId",
                table: "RecipeLike");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLike_Recipe_RecipeLikesId",
                table: "RecipeLike");

            migrationBuilder.RenameColumn(
                name: "UserLikesId",
                table: "RecipeLike",
                newName: "UserAccountId");

            migrationBuilder.RenameColumn(
                name: "RecipeLikesId",
                table: "RecipeLike",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLike_UserLikesId",
                table: "RecipeLike",
                newName: "IX_RecipeLike_UserAccountId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RecipeLike",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 19, 21, 33, 13, 165, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLike_AspNetUsers_UserAccountId",
                table: "RecipeLike",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLike_Recipe_RecipeId",
                table: "RecipeLike",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLike_AspNetUsers_UserAccountId",
                table: "RecipeLike");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLike_Recipe_RecipeId",
                table: "RecipeLike");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "RecipeLike");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "RecipeLike",
                newName: "UserLikesId");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "RecipeLike",
                newName: "RecipeLikesId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLike_UserAccountId",
                table: "RecipeLike",
                newName: "IX_RecipeLike_UserLikesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLike_AspNetUsers_UserLikesId",
                table: "RecipeLike",
                column: "UserLikesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLike_Recipe_RecipeLikesId",
                table: "RecipeLike",
                column: "RecipeLikesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
