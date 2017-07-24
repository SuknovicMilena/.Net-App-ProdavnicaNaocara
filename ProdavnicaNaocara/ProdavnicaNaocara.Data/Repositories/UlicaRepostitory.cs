using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using System.Linq;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class UlicaRepostitory : BaseRepository<Ulica>
    {
        public UlicaRepostitory(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {
        }

        public List<UlicaModel> GetAllUlica()
        {
            var ulice = dbSet.Select(u => new UlicaModel
            {
                Id = u.Id,
                Naziv = u.Naziv,
                MestoId = u.MestoId,
                NazivMesta = u.Mesto.Naziv
            }).ToList();
            return ulice;
        }
        public List<UlicaModel> GetAllUlicaPoMestima(int mestoId)
        {
            var ulice = dbSet.Where(u => u.MestoId == mestoId).Select(u => new UlicaModel
            {
                Id = u.Id,
                Naziv = u.Naziv,
                MestoId = u.MestoId,
                NazivMesta = u.Mesto.Naziv
            }).ToList();
            return ulice;
        }
    }
}
