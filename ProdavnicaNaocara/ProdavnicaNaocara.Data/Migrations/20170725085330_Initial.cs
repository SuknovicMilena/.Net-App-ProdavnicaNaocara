using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProdavnicaNaocara.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Katalozi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katalozi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ponude",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponude", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjaci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjaci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zaposleni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MestoId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ulice_Mesta_MestoId",
                        column: x => x.MestoId,
                        principalTable: "Mesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    ProizvodjacId = table.Column<int>(nullable: false),
                    Tip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proizvodi_Proizvodjaci_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Broj = table.Column<int>(nullable: false),
                    UlicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adrese_Ulice_UlicaId",
                        column: x => x.UlicaId,
                        principalTable: "Ulice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cene",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProizvodId = table.Column<int>(nullable: false),
                    IznosCene = table.Column<double>(nullable: false),
                    IznosPopusta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cena", x => new { x.Id, x.ProizvodId });
                    table.ForeignKey(
                        name: "FK_Cene_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeFakture",
                columns: table => new
                {
                    RbStavkeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FakturaId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaFakture", x => new { x.RbStavkeId, x.FakturaId });
                    table.UniqueConstraint("AK_StavkeFakture_RbStavkeId", x => x.RbStavkeId);
                    table.ForeignKey(
                        name: "FK_StavkeFakture_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeKataloga",
                columns: table => new
                {
                    RbStavkeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KatalogId = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaKataloga", x => new { x.RbStavkeId, x.KatalogId });
                    table.UniqueConstraint("AK_StavkeKataloga_RbStavkeId", x => x.RbStavkeId);
                    table.ForeignKey(
                        name: "FK_StavkeKataloga_Katalozi_KatalogId",
                        column: x => x.KatalogId,
                        principalTable: "Katalozi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeKataloga_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkePonude",
                columns: table => new
                {
                    RbStavkeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PonudaId = table.Column<int>(nullable: false),
                    Kolicnina = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    StatusPonude = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaPonude", x => new { x.RbStavkeId, x.PonudaId });
                    table.UniqueConstraint("AK_StavkePonude_RbStavkeId", x => x.RbStavkeId);
                    table.ForeignKey(
                        name: "FK_StavkePonude_Ponude_PonudaId",
                        column: x => x.PonudaId,
                        principalTable: "Ponude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkePonude_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdresaId = table.Column<int>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kupci_Adrese_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adrese",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbenice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    KupacId = table.Column<int>(nullable: false),
                    PonudaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbenice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzbenice_Kupci_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzbenice_Ponude_PonudaId",
                        column: x => x.PonudaId,
                        principalTable: "Ponude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZahteviZaPonudom",
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
                    table.PrimaryKey("PK_ZahteviZaPonudom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahteviZaPonudom_Katalozi_KatalogId",
                        column: x => x.KatalogId,
                        principalTable: "Katalozi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahteviZaPonudom_Kupci_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Otpremnice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumOtpreme = table.Column<DateTime>(nullable: false),
                    KupacId = table.Column<int>(nullable: false),
                    NarudzbenicaKupcaId = table.Column<int>(nullable: false),
                    ZaposleniId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otpremnice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Otpremnice_Kupci_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Otpremnice_Narudzbenice_NarudzbenicaKupcaId",
                        column: x => x.NarudzbenicaKupcaId,
                        principalTable: "Narudzbenice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Otpremnice_Zaposleni_ZaposleniId",
                        column: x => x.ZaposleniId,
                        principalTable: "Zaposleni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeNarudzbenice",
                columns: table => new
                {
                    RbStavkeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NarudzbenicaKupcaId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    PonudaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaNarudzbenice", x => new { x.RbStavkeId, x.NarudzbenicaKupcaId });
                    table.UniqueConstraint("AK_StavkeNarudzbenice_RbStavkeId", x => x.RbStavkeId);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbenice_Narudzbenice_NarudzbenicaKupcaId",
                        column: x => x.NarudzbenicaKupcaId,
                        principalTable: "Narudzbenice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbenice_Ponude_PonudaId",
                        column: x => x.PonudaId,
                        principalTable: "Ponude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Fakture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    OtpremnicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fakture_Otpremnice_OtpremnicaId",
                        column: x => x.OtpremnicaId,
                        principalTable: "Otpremnice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeOtpremnice",
                columns: table => new
                {
                    RbStavkeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OtpremnicaId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaOtpremnice", x => new { x.RbStavkeId, x.OtpremnicaId });
                    table.UniqueConstraint("AK_StavkeOtpremnice_RbStavkeId", x => x.RbStavkeId);
                    table.ForeignKey(
                        name: "FK_StavkeOtpremnice_Otpremnice_OtpremnicaId",
                        column: x => x.OtpremnicaId,
                        principalTable: "Otpremnice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeOtpremnice_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reklamacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    FakturaId = table.Column<int>(nullable: false),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reklamacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reklamacije_Fakture_FakturaId",
                        column: x => x.FakturaId,
                        principalTable: "Fakture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeReklamacije",
                columns: table => new
                {
                    RbStavkeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReklamacijaId = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaReklamacije", x => new { x.RbStavkeId, x.ReklamacijaId });
                    table.UniqueConstraint("AK_StavkeReklamacije_RbStavkeId", x => x.RbStavkeId);
                    table.ForeignKey(
                        name: "FK_StavkeReklamacije_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeReklamacije_Reklamacije_ReklamacijaId",
                        column: x => x.ReklamacijaId,
                        principalTable: "Reklamacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_UlicaId",
                table: "Adrese",
                column: "UlicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cene_ProizvodId",
                table: "Cene",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Fakture_OtpremnicaId",
                table: "Fakture",
                column: "OtpremnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kupci_AdresaId",
                table: "Kupci",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbenice_KupacId",
                table: "Narudzbenice",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbenice_PonudaId",
                table: "Narudzbenice",
                column: "PonudaId");

            migrationBuilder.CreateIndex(
                name: "IX_Otpremnice_KupacId",
                table: "Otpremnice",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Otpremnice_NarudzbenicaKupcaId",
                table: "Otpremnice",
                column: "NarudzbenicaKupcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Otpremnice_ZaposleniId",
                table: "Otpremnice",
                column: "ZaposleniId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_ProizvodjacId",
                table: "Proizvodi",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Reklamacije_FakturaId",
                table: "Reklamacije",
                column: "FakturaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeFakture_ProizvodId",
                table: "StavkeFakture",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeKataloga_KatalogId",
                table: "StavkeKataloga",
                column: "KatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeKataloga_ProizvodId",
                table: "StavkeKataloga",
                column: "ProizvodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbenice_NarudzbenicaKupcaId",
                table: "StavkeNarudzbenice",
                column: "NarudzbenicaKupcaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbenice_PonudaId",
                table: "StavkeNarudzbenice",
                column: "PonudaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeOtpremnice_OtpremnicaId",
                table: "StavkeOtpremnice",
                column: "OtpremnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeOtpremnice_ProizvodId",
                table: "StavkeOtpremnice",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkePonude_PonudaId",
                table: "StavkePonude",
                column: "PonudaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkePonude_ProizvodId",
                table: "StavkePonude",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeReklamacije_ProizvodId",
                table: "StavkeReklamacije",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeReklamacije_ReklamacijaId",
                table: "StavkeReklamacije",
                column: "ReklamacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ulice_MestoId",
                table: "Ulice",
                column: "MestoId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaPonudom_KatalogId",
                table: "ZahteviZaPonudom",
                column: "KatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaPonudom_KupacId",
                table: "ZahteviZaPonudom",
                column: "KupacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cene");

            migrationBuilder.DropTable(
                name: "StavkeFakture");

            migrationBuilder.DropTable(
                name: "StavkeKataloga");

            migrationBuilder.DropTable(
                name: "StavkeNarudzbenice");

            migrationBuilder.DropTable(
                name: "StavkeOtpremnice");

            migrationBuilder.DropTable(
                name: "StavkePonude");

            migrationBuilder.DropTable(
                name: "StavkeReklamacije");

            migrationBuilder.DropTable(
                name: "ZahteviZaPonudom");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Reklamacije");

            migrationBuilder.DropTable(
                name: "Katalozi");

            migrationBuilder.DropTable(
                name: "Proizvodjaci");

            migrationBuilder.DropTable(
                name: "Fakture");

            migrationBuilder.DropTable(
                name: "Otpremnice");

            migrationBuilder.DropTable(
                name: "Narudzbenice");

            migrationBuilder.DropTable(
                name: "Zaposleni");

            migrationBuilder.DropTable(
                name: "Kupci");

            migrationBuilder.DropTable(
                name: "Ponude");

            migrationBuilder.DropTable(
                name: "Adrese");

            migrationBuilder.DropTable(
                name: "Ulice");

            migrationBuilder.DropTable(
                name: "Mesta");
        }
    }
}
