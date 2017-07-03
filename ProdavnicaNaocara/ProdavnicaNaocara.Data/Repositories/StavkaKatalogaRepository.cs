using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using System.Linq;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class StavkaKatalogaRepository : BaseRepository<StavkaKataloga>
    {
        public StavkaKatalogaRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext) { }

        public List<StavkaKatalogaModel> GetAllStavkaKatalogaModel()
        {
            var stavke = dbSet.Select(sk => new StavkaKatalogaModel
            {
                RBStavke = sk.RbStavkeId,
                KatalogId = sk.KatalogId,
                NazivKataloga = sk.Katalog.Naziv,
                ProizvodId = sk.ProizvodId,
                NazivProizvoda = sk.ProizvodStavke.Ime,
                Status = sk.Status


            }).ToList();
            return stavke;


        }

    }
}
