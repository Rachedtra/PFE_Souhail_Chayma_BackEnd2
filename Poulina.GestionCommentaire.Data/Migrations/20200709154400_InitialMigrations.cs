using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.GestionCommentaire.Data.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCat = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    IsActiveCat = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCat);
                });

            migrationBuilder.CreateTable(
                name: "DemandeInformation",
                columns: table => new
                {
                    IdDemandeInfo = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsActiveInfo = table.Column<bool>(nullable: false),
                    Titre = table.Column<string>(nullable: true),
                    IdDomain = table.Column<Guid>(nullable: false)
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
                    Note = table.Column<int>(nullable: false),
                    IsActiveVote = table.Column<bool>(nullable: false)
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
                    CatFK = table.Column<Guid>(nullable: false),
                    IsActiveSousCat = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousCategories", x => x.IdSousCate);
                    table.ForeignKey(
                        name: "FK_SousCategories_Categories_CatFK",
                        column: x => x.CatFK,
                        principalTable: "Categories",
                        principalColumn: "IdCat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatDemandeInfos",
                columns: table => new
                {
                    IdCatDemande = table.Column<Guid>(nullable: false),
                    IdCat = table.Column<Guid>(nullable: true),
                    IdDemandeInfo = table.Column<Guid>(nullable: false),
                    IsActiveCatInfo = table.Column<bool>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    IdComm = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsActiveComm = table.Column<bool>(nullable: false),
                    FkInfo = table.Column<Guid>(nullable: true),
                    FkMs = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.IdComm);
                    table.ForeignKey(
                        name: "FK_Commentaires_DemandeInformation_FkInfo",
                        column: x => x.FkInfo,
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
                    IdVote = table.Column<Guid>(nullable: true),
                    IsActiveCommVote = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommVotes", x => x.IdCommVote);
                    table.ForeignKey(
                        name: "FK_CommVotes_Commentaires_IdComm",
                        column: x => x.IdComm,
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
                name: "IX_Commentaires_FkInfo",
                table: "Commentaires",
                column: "FkInfo");

            migrationBuilder.CreateIndex(
                name: "IX_CommVotes_IdComm",
                table: "CommVotes",
                column: "IdComm");

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
                name: "CommVotes");

            migrationBuilder.DropTable(
                name: "SousCategories");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DemandeInformation");
        }
    }
}
