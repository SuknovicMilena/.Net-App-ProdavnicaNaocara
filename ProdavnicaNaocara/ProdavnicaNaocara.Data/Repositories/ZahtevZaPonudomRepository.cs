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
                Datum = z.Datum,
                KatalogId = z.KatalogId,
                KatalogNaziv = z.Katalog.Naziv,
                KupacId = z.KupacId,
                KupacNaziv = z.Kupac.Naziv



            }).ToList();
            return zahtevi;
        }
    }
}
