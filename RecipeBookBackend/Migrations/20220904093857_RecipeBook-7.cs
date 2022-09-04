using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBookBackend.Migrations
{
    public partial class RecipeBook7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeFavorite",
                columns: table => new
                {
                    RecipeFavoritesId = table.Column<int>(type: "int", nullable: false),
                    UserFavoritesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeFavorite", x => new { x.RecipeFavoritesId, x.UserFavoritesId });
                    table.ForeignKey(
                        name: "FK_RecipeFavorite_AspNetUsers_UserFavoritesId",
                        column: x => x.UserFavoritesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeFavorite_Recipe_RecipeFavoritesId",
                        column: x => x.RecipeFavoritesId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeLike",
                columns: table => new
                {
                    RecipeLikesId = table.Column<int>(type: "int", nullable: false),
                    UserLikesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLike", x => new { x.RecipeLikesId, x.UserLikesId });
                    table.ForeignKey(
                        name: "FK_RecipeLike_AspNetUsers_UserLikesId",
                        column: x => x.UserLikesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeLike_Recipe_RecipeLikesId",
                        column: x => x.RecipeLikesId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFavorite_UserFavoritesId",
                table: "RecipeFavorite",
                column: "UserFavoritesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLike_UserLikesId",
                table: "RecipeLike",
                column: "UserLikesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeFavorite");

            migrationBuilder.DropTable(
                name: "RecipeLike");
        }
    }
}
