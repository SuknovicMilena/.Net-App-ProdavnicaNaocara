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
    partial class ProdavnicaNaocaraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Faktura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<int>("OtpremnicaId");

                    b.HasKey("Id");

                    b.HasIndex("OtpremnicaId");

                    b.ToTable("Fakture");
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

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("AdresaId");

                    b.ToTable("Kupci");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Mesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Mesta");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Narudzbenica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("KupacId");

                    b.Property<int>("PonudaId");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.HasIndex("PonudaId");

                    b.ToTable("Narudzbenice");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Otpremnica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumOtpreme");

                    b.Property<int>("KupacId");

                    b.Property<int>("NarudzbenicaKupcaId");

                    b.Property<int>("ZaposleniId");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.HasIndex("NarudzbenicaKupcaId");

                    b.HasIndex("ZaposleniId");

                    b.ToTable("Otpremnice");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Ponuda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<string>("Napomena");

                    b.HasKey("Id");

                    b.ToTable("Ponude");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Proizvod", b =>
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

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Proizvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Proizvodjaci");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Reklamacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("FakturaId");

                    b.Property<string>("Napomena");

                    b.HasKey("Id");

                    b.HasIndex("FakturaId");

                    b.ToTable("Reklamacije");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaFakture", b =>
                {
                    b.Property<int>("RbStavkeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FakturaId");

                    b.Property<int>("Kolicina");

                    b.Property<int>("ProizvodId");

                    b.HasKey("RbStavkeId", "FakturaId")
                        .HasName("PK_StavkaFakture");

                    b.HasAlternateKey("RbStavkeId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("StavkeFakture");
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

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaNarudzbenice", b =>
                {
                    b.Property<int>("RbStavkeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NarudzbenicaKupcaId");

                    b.Property<int>("Kolicina");

                    b.Property<int>("PonudaId");

                    b.HasKey("RbStavkeId", "NarudzbenicaKupcaId")
                        .HasName("PK_StavkaNarudzbenice");

                    b.HasAlternateKey("RbStavkeId");

                    b.HasIndex("NarudzbenicaKupcaId");

                    b.HasIndex("PonudaId");

                    b.ToTable("StavkeNarudzbenice");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaOtpremnice", b =>
                {
                    b.Property<int>("RbStavkeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OtpremnicaId");

                    b.Property<int>("Kolicina");

                    b.Property<int>("ProizvodId");

                    b.HasKey("RbStavkeId", "OtpremnicaId")
                        .HasName("PK_StavkaOtpremnice");

                    b.HasAlternateKey("RbStavkeId");

                    b.HasIndex("OtpremnicaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("StavkeOtpremnice");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaPonude", b =>
                {
                    b.Property<int>("RbStavkeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PonudaId");

                    b.Property<int>("Kolicnina");

                    b.Property<int>("ProizvodId");

                    b.Property<int>("StatusPonude");

                    b.HasKey("RbStavkeId", "PonudaId")
                        .HasName("PK_StavkaPonude");

                    b.HasAlternateKey("RbStavkeId");

                    b.HasIndex("PonudaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("StavkePonude");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaReklamacije", b =>
                {
                    b.Property<int>("RbStavkeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ReklamacijaId");

                    b.Property<string>("Opis");

                    b.Property<int>("ProizvodId");

                    b.HasKey("RbStavkeId", "ReklamacijaId")
                        .HasName("PK_StavkaReklamacije");

                    b.HasAlternateKey("RbStavkeId");

                    b.HasIndex("ProizvodId");

                    b.HasIndex("ReklamacijaId");

                    b.ToTable("StavkeReklamacije");
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

                    b.ToTable("ZahteviZaPonudom");
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Zaposleni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Zaposleni");
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
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Proizvod", "Proizvod")
                        .WithMany("Cene")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Faktura", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Otpremnica", "Otpremnica")
                        .WithMany("Otpremnice")
                        .HasForeignKey("OtpremnicaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Kupac", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Adresa", "Adresa")
                        .WithMany("Kupci")
                        .HasForeignKey("AdresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Narudzbenica", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Kupac", "KupacNarudzbenica")
                        .WithMany("KupciNarudzbenica")
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Entities.Ponuda", "Ponuda")
                        .WithMany("Ponude")
                        .HasForeignKey("PonudaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Otpremnica", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Kupac", "KupacOtprema")
                        .WithMany("KupaciZaOtpremu")
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Entities.Narudzbenica", "NarudzbenicaKupca")
                        .WithMany("OtpremniceNaOsnovuNarudzbenice")
                        .HasForeignKey("NarudzbenicaKupcaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Entities.Zaposleni", "Zaposlen")
                        .WithMany("OtpremnicaZaposleni")
                        .HasForeignKey("ZaposleniId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Proizvod", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Proizvodjac", "Proizvodjac")
                        .WithMany("Proizvodi")
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.Reklamacija", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Faktura", "Faktura")
                        .WithMany("Reklamacije")
                        .HasForeignKey("FakturaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaFakture", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Proizvod", "ProizvodFakt")
                        .WithMany("ProizvodiUFakt")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaKataloga", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Katalog", "Katalog")
                        .WithMany("Stavke")
                        .HasForeignKey("KatalogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Entities.Proizvod", "ProizvodStavke")
                        .WithOne("Stavka")
                        .HasForeignKey("ProdavnicaNaocara.Data.Entities.StavkaKataloga", "ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaNarudzbenice", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Narudzbenica", "Narudzbenica")
                        .WithMany("Narudzbenice")
                        .HasForeignKey("NarudzbenicaKupcaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Entities.Ponuda", "PonudaZaNar")
                        .WithMany("PonudeZaNar")
                        .HasForeignKey("PonudaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaOtpremnice", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Otpremnica", "OtpremnicaS")
                        .WithMany("StavkeOtpremnice")
                        .HasForeignKey("OtpremnicaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Entities.Proizvod", "ProizvodOtpremnica")
                        .WithMany("StavkeOtpremnice")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaPonude", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Ponuda", "PonudaStavki")
                        .WithMany("StavkePonude")
                        .HasForeignKey("PonudaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Entities.Proizvod", "ProizvodPonuda")
                        .WithMany("ProizvodiPonuda")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProdavnicaNaocara.Data.Entities.StavkaReklamacije", b =>
                {
                    b.HasOne("ProdavnicaNaocara.Data.Entities.Proizvod", "ProizvodZaReklamaciju")
                        .WithMany("StavkeReklamacije")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdavnicaNaocara.Data.Entities.Reklamacija", "Reklamacija")
                        .WithMany("StavkeReklamacije")
                        .HasForeignKey("ReklamacijaId")
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
        }
    }
}
