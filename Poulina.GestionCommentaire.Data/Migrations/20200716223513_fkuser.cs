using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.GestionCommentaire.Data.Migrations
{
    public partial class fkuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FkUser",
                table: "DemandeInformation",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FkUser",
                table: "Commentaires",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FkUser",
                table: "DemandeInformation");

            migrationBuilder.DropColumn(
                name: "FkUser",
                table: "Commentaires");
        }
    }
}
