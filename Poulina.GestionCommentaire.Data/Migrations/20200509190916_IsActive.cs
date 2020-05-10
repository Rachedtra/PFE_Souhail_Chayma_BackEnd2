using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.GestionCommentaire.Data.Migrations
{
    public partial class IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActiveVote",
                table: "Votes",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveSousCat",
                table: "SousCategories",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveInfo",
                table: "DemandeInformation",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveCommVote",
                table: "CommVotes",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveComm",
                table: "Commentaires",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveCommInfo",
                table: "CommDemandeInfos",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveCat",
                table: "Categories",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveCatInfo",
                table: "CatDemandeInfos",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveVote",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsActiveSousCat",
                table: "SousCategories");

            migrationBuilder.DropColumn(
                name: "IsActiveInfo",
                table: "DemandeInformation");

            migrationBuilder.DropColumn(
                name: "IsActiveCommVote",
                table: "CommVotes");

            migrationBuilder.DropColumn(
                name: "IsActiveComm",
                table: "Commentaires");

            migrationBuilder.DropColumn(
                name: "IsActiveCommInfo",
                table: "CommDemandeInfos");

            migrationBuilder.DropColumn(
                name: "IsActiveCat",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsActiveCatInfo",
                table: "CatDemandeInfos");
        }
    }
}
