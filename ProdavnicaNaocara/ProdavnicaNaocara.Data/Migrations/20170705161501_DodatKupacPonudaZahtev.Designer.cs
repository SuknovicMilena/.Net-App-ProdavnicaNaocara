using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProdavnicaNaocara.Data;
using ProdavnicaNaocara.Common.Enums;

namespace ProdavnicaNaocara.Data.Migrations
{
    [DbContext(typeof(ProdavnicaNaocaraDbContext))]
    [Migration("20170705161501_DodatKupacPonudaZahtev")]
    partial class DodatKupacPonudaZahtev
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Adresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Broj");

                    b.Property<int>("UlicaId");

                    b.HasKey("Id");

                    b.HasIndex("UlicaId");

                    b.ToTable("Adrese");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Cena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProizvodId");

                    b.Property<double>("IznosCene");

                    b.Property<int>("IznosPopusta");

                    b.HasKey("Id", "ProizvodId")
                        .HasName("PK_Cena");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Cene");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Katalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Katalozi");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Kupac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdresaId");

                    b.Property<string>("BrojTelefona");

                    b.Property<string>("naziv");

                    b.HasKey("Id");

                    b.HasIndex("AdresaId");

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Mesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Mesta");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.PonudaKupcu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<string>("Napomena");

                    b.Property<int>("ZahtevId");

                    b.HasKey("Id");

                    b.HasIndex("ZahtevId")
                        .IsUnique();

                    b.ToTable("PonudaKupcu");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaKataloga", b =>
                {
                    b.Property<int>("RbStavkeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KatalogId");

                    b.Property<int>("ProizvodId");

                    b.Property<string>("Status");

                    b.HasKey("RbStavkeId", "KatalogId")
                        .HasName("PK_StavkaKataloga");

                    b.HasAlternateKey("RbStavkeId");

                    b.HasIndex("KatalogId");

                    b.HasIndex("ProizvodId")
                        .IsUnique();

                    b.ToTable("StavkeKataloga");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Ulica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MestoId");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("MestoId");

                    b.ToTable("Ulice");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.ZahtevZaPonudom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("KatalogId");

                    b.Property<int>("KupacId");

                    b.HasKey("Id");

                    b.HasIndex("KatalogId");

                    b.HasIndex("KupacId");

                    b.ToTable("ZahtevZaPonudom");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Zaposleni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Zaposleni");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<int>("ProizvodjacId");

                    b.Property<int>("Tip");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodjacId");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Models.Proizvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Proizvodjaci");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Adresa", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Ulica", "Ulica")
                        .WithMany("Adrese")
                        .HasForeignKey("UlicaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Cena", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Models.Proizvod", "Proizvod")
                        .WithMany("Cene")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Kupac", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Adresa", "Adresa")
                        .WithMany("Kupci")
                        .HasForeignKey("AdresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.PonudaKupcu", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.ZahtevZaPonudom", "ZahtevZaPonudom")
                        .WithOne("PonudaKupcu")
                        .HasForeignKey("ProdavnicaNaocara.Data.Entities.PonudaKupcu", "ZahtevId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaKataloga", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Katalog", "Katalog")
                        .WithMany("Stavke")
                        .HasForeignKey("KatalogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Models.Proizvod", "ProizvodStavke")
                        .WithOne("Stavka")
                        .HasForeignKey("ProdavnicaNaocara.Data.Entities.StavkaKataloga", "ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Ulica", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Mesto", "Mesto")
                        .WithMany("Ulice")
                        .HasForeignKey("MestoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.ZahtevZaPonudom", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Katalog", "Katalog")
                        .WithMany("ZahteviZaPonudom")
                        .HasForeignKey("KatalogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Entities.Kupac", "Kupac")
                        .WithMany("ZahteviZaPonudom")
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Models.Proizvod", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Models.Proizvodjac", "Proizvodjac")
                        .WithMany("Proizvodi")
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
