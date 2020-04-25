using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.GestionCommentaire.Data.Migrations
{
    public partial class DeleteBehav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SousCategories_Categories_CatFK",
                table: "SousCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_SousCategories_Categories_CatFK",
                table: "SousCategories",
                column: "CatFK",
                principalTable: "Categories",
                principalColumn: "IdCat",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SousCategories_Categories_CatFK",
                table: "SousCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_SousCategories_Categories_CatFK",
                table: "SousCategories",
                column: "CatFK",
                principalTable: "Categories",
                principalColumn: "IdCat",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
