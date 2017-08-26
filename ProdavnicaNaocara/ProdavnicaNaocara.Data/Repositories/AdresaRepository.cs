using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Data.Entities;
using ProdavnicaNaocara.Common.Models;
using System.Linq;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class AdresaRepository : BaseRepository<Adresa>
    {
        public AdresaRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {
        }

        public List<AdresaModel> getAllAdresaModel()
        {
            var adrese = dbSet.Select(a => new AdresaModel
            {
                Id = a.Id,
                Broj = a.Broj,
                UlicaId = a.UlicaId,
                NazivUlice = a.Ulica.Naziv

            }).ToList();
            return adrese;
        }

    }
}
