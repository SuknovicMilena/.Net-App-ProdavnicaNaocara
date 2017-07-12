using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaNaocara.Data
{
    public class ProdavnicaNaocaraDbContext : DbContext
    {
        public DbSet<Proizvodjac> Proizvodjaci { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Cena> Cene { get; set; }
        public DbSet<Katalog> Katalozi { get; set; }
        public DbSet<StavkaKataloga> StavkeKataloga { get; set; }

        public DbSet<Mesto> Mesta { get; set; }
        public DbSet<Ulica> Ulice { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public DbSet<Zaposleni> Zaposleni { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Ponuda> Ponude { get; set; }
        public DbSet<ZahtevZaPonudom> ZahteviZaPonudom { get; set; }
        public DbSet<Narudzbenica> Narudzbenice { get; set; }

        public DbSet<StavkaNarudzbenice> StavkeNarudzbenice { get; set; }
        public DbSet<Otpremnica> Otpremnice { get; set; }

        public DbSet<StavkaPonude> StavkePonude { get; set; }
        public DbSet<Faktura> Fakture { get; set; }
        public DbSet<StavkaFakture> StavkeFakture { get; set; }
        public DbSet<StavkaOtpremnice> StavkeOtpremnice { get; set; }
        public DbSet<Reklamacija> Reklamacije { get; set; }
        public DbSet<StavkaReklamacije> StavkeReklamacije { get; set; }

        public ProdavnicaNaocaraDbContext(DbContextOptions<ProdavnicaNaocaraDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cena>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ProizvodId })
                .HasName("PK_Cena");
            });

            modelBuilder.Entity<StavkaKataloga>(entity =>
            {
                entity.HasKey(e => new { e.RbStavkeId, e.KatalogId })
               .HasName("PK_StavkaKataloga");
            });

            modelBuilder.Entity<StavkaPonude>(entity =>
            {
                entity.HasKey(e => new { e.RbStavkeId, e.PonudaId })
               .HasName("PK_StavkaPonude");


            });
            modelBuilder.Entity<StavkaNarudzbenice>(entity =>
            {
                entity.HasKey(e => new { e.RbStavkeId, e.NarudzbenicaKupcaId })
               .HasName("PK_StavkaNarudzbenice");


            });
            modelBuilder.Entity<StavkaFakture>(entity =>
            {
                entity.HasKey(e => new { e.RbStavkeId, e.FakturaId })
               .HasName("PK_StavkaFakture");


            });
            modelBuilder.Entity<StavkaOtpremnice>(entity =>
            {
                entity.HasKey(e => new { e.RbStavkeId, e.OtpremnicaId })
               .HasName("PK_StavkaOtpremnice");


            });
            modelBuilder.Entity<StavkaReklamacije>(entity =>
            {
                entity.HasKey(e => new { e.RbStavkeId, e.ReklamacijaId })
               .HasName("PK_StavkaReklamacije");


            });
        }


    }
}
