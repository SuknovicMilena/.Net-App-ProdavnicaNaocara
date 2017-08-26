using ProdavnicaNaocara.Common.Models;
using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class KatalogRepository : BaseRepository<Katalog>
    {
        public KatalogRepository(ProdavnicaNaocaraDbContext dbContex) : base(dbContex)
        {

        }

        public List<KatalogModel> GetAllKatalogModels()
        {
            var katalog = dbSet.Select(kat => new KatalogModel
            {
                Id = kat.Id,
                Naziv = kat.Naziv
            }).ToList();
            return katalog;
        }


    }
}
