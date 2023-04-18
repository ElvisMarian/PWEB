using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class migrare_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:unaccent", ",,");

            migrationBuilder.CreateTable(
                name: "Recenzie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Produs = table.Column<string>(type: "text", nullable: false),
                    User = table.Column<string>(type: "text", nullable: false),
                    Nota = table.Column<int>(type: "integer", nullable: false),
                    TextRecenzie = table.Column<string>(type: "text", nullable: false),
                    DataRecenzie = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Wishlist = table.Column<List<string>>(type: "text[]", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Strada = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Oras = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Tara = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adrese_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adrese_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(4095)", maxLength: 4095, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFile_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cantitate = table.Column<int>(type: "integer", nullable: false),
                    PretTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    AdresaLivrareId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusComanda = table.Column<string>(type: "text", nullable: false),
                    UtilizatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comenzi_Adrese_AdresaLivrareId",
                        column: x => x.AdresaLivrareId,
                        principalTable: "Adrese",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comenzi_User_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Livrari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataLivrare = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NumeCurier = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AdresaLivrareId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livrari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livrari_Adrese_AdresaLivrareId",
                        column: x => x.AdresaLivrareId,
                        principalTable: "Adrese",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Livrari_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nume = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descriere = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Pret = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Categorie = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<decimal>(type: "numeric(2,1)", nullable: false),
                    Disponibilitate = table.Column<int>(type: "integer", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produse_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecenziiProduse",
                columns: table => new
                {
                    RecenzieId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecenziiProduse", x => new { x.RecenzieId, x.ProdusId });
                    table.ForeignKey(
                        name: "FK_RecenziiProduse_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecenziiProduse_Recenzie_RecenzieId",
                        column: x => x.RecenzieId,
                        principalTable: "Recenzie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_UserId",
                table: "Adrese",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_UserId1",
                table: "Adrese",
                column: "UserId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_AdresaLivrareId",
                table: "Comenzi",
                column: "AdresaLivrareId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Livrari_AdresaLivrareId",
                table: "Livrari",
                column: "AdresaLivrareId");

            migrationBuilder.CreateIndex(
                name: "IX_Livrari_ComandaId",
                table: "Livrari",
                column: "ComandaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produse_ComandaId",
                table: "Produse",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_RecenziiProduse_ProdusId",
                table: "RecenziiProduse",
                column: "ProdusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFile_UserId",
                table: "UserFile",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livrari");

            migrationBuilder.DropTable(
                name: "RecenziiProduse");

            migrationBuilder.DropTable(
                name: "UserFile");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Recenzie");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "Adrese");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
