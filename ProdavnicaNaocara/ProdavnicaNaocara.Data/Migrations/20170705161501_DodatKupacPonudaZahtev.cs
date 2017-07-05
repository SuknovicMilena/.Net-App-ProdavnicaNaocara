using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProdavnicaNaocara.Data.Migrations
{
    public partial class DodatKupacPonudaZahtev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdresaId = table.Column<int>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: true),
                    naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kupac_Adrese_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adrese",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZahtevZaPonudom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    KatalogId = table.Column<int>(nullable: false),
                    KupacId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtevZaPonudom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahtevZaPonudom_Katalozi_KatalogId",
                        column: x => x.KatalogId,
                        principalTable: "Katalozi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahtevZaPonudom_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PonudaKupcu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    ZahtevId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonudaKupcu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PonudaKupcu_ZahtevZaPonudom_ZahtevId",
                        column: x => x.ZahtevId,
                        principalTable: "ZahtevZaPonudom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_AdresaId",
                table: "Kupac",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_PonudaKupcu_ZahtevId",
                table: "PonudaKupcu",
                column: "ZahtevId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaPonudom_KatalogId",
                table: "ZahtevZaPonudom",
                column: "KatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtevZaPonudom_KupacId",
                table: "ZahtevZaPonudom",
                column: "KupacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PonudaKupcu");

            migrationBuilder.DropTable(
                name: "ZahtevZaPonudom");

            migrationBuilder.DropTable(
                name: "Kupac");
        }
    }
}
