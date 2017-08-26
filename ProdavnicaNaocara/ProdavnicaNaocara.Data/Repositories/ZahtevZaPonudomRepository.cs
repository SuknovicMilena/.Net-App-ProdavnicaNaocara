using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ProdavnicaNaocara.Common.Models;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class ZahtevZaPonudomRepository : BaseRepository<ZahtevZaPonudom>
    {
        public ZahtevZaPonudomRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {
        }
        public List<ZahtevZaPonudomModel> GetAllZahtevZaPonudomModel()
        {
            var zahtevi = dbSet.Select(z => new ZahtevZaPonudomModel
            {
                Id = z.Id,
                KatalogNaziv = z.Katalog.Naziv
            }).ToList();
            return zahtevi;
        }
        public List<ZahtevZaPonudomModel> GetAllZahteviZaKupca(int kupacId)
        {
            var zahtevi = dbSet.Where(z => z.KupacId == kupacId).Select(z => new ZahtevZaPonudomModel
            {
                Id = z.Id,
                KatalogNaziv = z.Katalog.Naziv,
                KupacId = z.KupacId,
                KupacNaziv = z.Kupac.Naziv
            }).ToList();
            return zahtevi;
        }

        public ZahtevZaPonudomModel GetAllZahtevById(int zahtevId)
        {
            var zahtev = dbSet.Select(z => new ZahtevZaPonudomModel
            {
                Id = z.Id,
                KatalogNaziv = z.Katalog.Naziv,
                KupacId = z.KupacId,
                KupacNaziv = z.Kupac.Naziv
            }).FirstOrDefault(z => z.Id == zahtevId);
            return zahtev;
        }
    }
}
