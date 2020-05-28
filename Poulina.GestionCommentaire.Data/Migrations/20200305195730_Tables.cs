using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.GestionCommentaire.Data.Migrations
{
    public partial class Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {

                    IdCat = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCat);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    IdComm = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.IdComm);
                });

            migrationBuilder.CreateTable(
                name: "DemandeInformation",
                columns: table => new
                {
                    IdDemandeInfo = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeInformation", x => x.IdDemandeInfo);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    IdVote = table.Column<Guid>(nullable: false),
                    Note = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.IdVote);
                });

            migrationBuilder.CreateTable(
                name: "SousCategories",
                columns: table => new
                {
                    IdSousCate = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    CatFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousCategories", x => x.IdSousCate);
                    table.ForeignKey(
                        name: "FK_SousCategories_Categories_CatFK",
                        column: x => x.CatFK,
                        principalTable: "Categories",
                        principalColumn: "IdCat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatDemandeInfos",
                columns: table => new
                {
                    IdCatDemande = table.Column<Guid>(nullable: false),
                    IdCat = table.Column<Guid>(nullable: true),
                    IdDemandeInfo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDemandeInfos", x => x.IdCatDemande);
                    table.ForeignKey(
                        name: "FK_CatDemandeInfos_Categories_IdCat",
                        column: x => x.IdCat,
                        principalTable: "Categories",
                        principalColumn: "IdCat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatDemandeInfos_DemandeInformation_IdDemandeInfo",
                        column: x => x.IdDemandeInfo,
                        principalTable: "DemandeInformation",
                        principalColumn: "IdDemandeInfo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommDemandeInfos",
                columns: table => new
                {
                    IdCommInfo = table.Column<Guid>(nullable: false),
                    IdDemandeInfo = table.Column<Guid>(nullable: true),
                    IdComm = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommDemandeInfos", x => x.IdCommInfo);
                    table.ForeignKey(
                        name: "FK_CommDemandeInfos_Commentaires_IdComm",
                        column: x => x.IdComm,
                        principalTable: "Commentaires",
                        principalColumn: "IdComm",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommDemandeInfos_DemandeInformation_IdDemandeInfo",
                        column: x => x.IdDemandeInfo,
                        principalTable: "DemandeInformation",
                        principalColumn: "IdDemandeInfo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommVotes",
                columns: table => new
                {
                    IdCommVote = table.Column<Guid>(nullable: false),
                    IdComm = table.Column<Guid>(nullable: true),
                    IdVote = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommVotes", x => x.IdCommVote);
                    table.ForeignKey(
                        name: "FK_CommVotes_Commentaires_IdVote",
                        column: x => x.IdVote,
                        principalTable: "Commentaires",
                        principalColumn: "IdComm",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommVotes_Votes_IdVote",
                        column: x => x.IdVote,
                        principalTable: "Votes",
                        principalColumn: "IdVote",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatDemandeInfos_IdCat",
                table: "CatDemandeInfos",
                column: "IdCat");

            migrationBuilder.CreateIndex(
                name: "IX_CatDemandeInfos_IdDemandeInfo",
                table: "CatDemandeInfos",
                column: "IdDemandeInfo");

            migrationBuilder.CreateIndex(
                name: "IX_CommDemandeInfos_IdComm",
                table: "CommDemandeInfos",
                column: "IdComm");

            migrationBuilder.CreateIndex(
                name: "IX_CommDemandeInfos_IdDemandeInfo",
                table: "CommDemandeInfos",
                column: "IdDemandeInfo");

            migrationBuilder.CreateIndex(
                name: "IX_CommVotes_IdVote",
                table: "CommVotes",
                column: "IdVote");

            migrationBuilder.CreateIndex(
                name: "IX_SousCategories_CatFK",
                table: "SousCategories",
                column: "CatFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatDemandeInfos");

            migrationBuilder.DropTable(
                name: "CommDemandeInfos");

            migrationBuilder.DropTable(
                name: "CommVotes");

            migrationBuilder.DropTable(
                name: "SousCategories");

            migrationBuilder.DropTable(
                name: "DemandeInformation");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
