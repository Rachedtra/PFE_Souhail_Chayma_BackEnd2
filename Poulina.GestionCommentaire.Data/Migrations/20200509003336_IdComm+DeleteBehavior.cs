using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.GestionCommentaire.Data.Migrations
{
    public partial class IdCommDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatDemandeInfos_DemandeInformation_IdDemandeInfo",
                table: "CatDemandeInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_CommVotes_Commentaires_IdVote",
                table: "CommVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SousCategories_Categories_CatFK",
                table: "SousCategories");

            migrationBuilder.CreateIndex(
                name: "IX_CommVotes_IdComm",
                table: "CommVotes",
                column: "IdComm");

            migrationBuilder.AddForeignKey(
                name: "FK_CatDemandeInfos_DemandeInformation_IdDemandeInfo",
                table: "CatDemandeInfos",
                column: "IdDemandeInfo",
                principalTable: "DemandeInformation",
                principalColumn: "IdDemandeInfo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommVotes_Commentaires_IdComm",
                table: "CommVotes",
                column: "IdComm",
                principalTable: "Commentaires",
                principalColumn: "IdComm",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_CatDemandeInfos_DemandeInformation_IdDemandeInfo",
                table: "CatDemandeInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_CommVotes_Commentaires_IdComm",
                table: "CommVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SousCategories_Categories_CatFK",
                table: "SousCategories");

            migrationBuilder.DropIndex(
                name: "IX_CommVotes_IdComm",
                table: "CommVotes");

            migrationBuilder.AddForeignKey(
                name: "FK_CatDemandeInfos_DemandeInformation_IdDemandeInfo",
                table: "CatDemandeInfos",
                column: "IdDemandeInfo",
                principalTable: "DemandeInformation",
                principalColumn: "IdDemandeInfo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommVotes_Commentaires_IdVote",
                table: "CommVotes",
                column: "IdVote",
                principalTable: "Commentaires",
                principalColumn: "IdComm",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SousCategories_Categories_CatFK",
                table: "SousCategories",
                column: "CatFK",
                principalTable: "Categories",
                principalColumn: "IdCat",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
