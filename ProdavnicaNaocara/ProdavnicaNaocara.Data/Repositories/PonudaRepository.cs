using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using System.Linq;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class PonudaRepository : BaseRepository<Ponuda>
    {
        public PonudaRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {

        }

        public List<PonudaModel> GetAllPonudaModel()
        {
            var ponude = dbSet.Select(p => new PonudaModel
            {
                Id = p.Id,
                Datum = p.Datum,
                Napomena = p.Napomena,
                ZahtevId = p.ZahtevZaPonudom.Id,
                ZahtevNaziv = p.ZahtevZaPonudom.Katalog.Naziv


            }).ToList();

            return ponude;

        }
        public PonudaModel GetAllPonudaModelById(int Id)
        {
            var ponuda = dbSet.Select(p => new PonudaModel
            {
                Id = p.Id,
                Datum = p.Datum,
                Napomena = p.Napomena,
                ZahtevId = p.ZahtevZaPonudom.Id,
                ZahtevNaziv = p.ZahtevZaPonudom.Katalog.Naziv

            }).FirstOrDefault(p => p.Id == Id);
            return ponuda;

        }

    }
}
