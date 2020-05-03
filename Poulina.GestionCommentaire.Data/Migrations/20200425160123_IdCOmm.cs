using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.GestionCommentaire.Data.Migrations
{
    public partial class IdCOmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommVotes_Commentaires_IdVote",
                table: "CommVotes");

            migrationBuilder.CreateIndex(
                name: "IX_CommVotes_IdComm",
                table: "CommVotes",
                column: "IdComm");

            migrationBuilder.AddForeignKey(
                name: "FK_CommVotes_Commentaires_IdComm",
                table: "CommVotes",
                column: "IdComm",
                principalTable: "Commentaires",
                principalColumn: "IdComm",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommVotes_Commentaires_IdComm",
                table: "CommVotes");

            migrationBuilder.DropIndex(
                name: "IX_CommVotes_IdComm",
                table: "CommVotes");

            migrationBuilder.AddForeignKey(
                name: "FK_CommVotes_Commentaires_IdVote",
                table: "CommVotes",
                column: "IdVote",
                principalTable: "Commentaires",
                principalColumn: "IdComm",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
