using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Data.Entities;
using ProdavnicaNaocara.Data.Models;
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
        }
    }
}
