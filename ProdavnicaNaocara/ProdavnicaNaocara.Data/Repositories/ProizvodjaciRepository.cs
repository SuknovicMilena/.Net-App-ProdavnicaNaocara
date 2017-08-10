using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using System.Linq;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class ProizvodjaciRepository : BaseRepository<Proizvodjac>
    {
        public ProizvodjaciRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {
            
        }
        public List<ProizvodjacModel> GetAllProizvodjacModels()
        {
            var proizvodjaci = dbSet.Select(p => new ProizvodjacModel
            {
                Id = p.Id,
                Ime = p.Ime,
            }).ToList();

            return proizvodjaci;
        }


        public ProizvodjacModel GetProizvodjacModelById(int id)
        {
            var proizvodjac = dbSet.Select(p => new ProizvodjacModel
            {
                Id = p.Id,
                Ime = p.Ime,
            }).FirstOrDefault(p => p.Id == id);

            return proizvodjac;
        }
    }
}
