using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using System.Linq;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class ProizvodiRepository : BaseRepository<Proizvod>
    {
        public ProizvodiRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {
        }

        public List<ProizvodModel> GetAllProizvodModels()
        {
            var proizvodi = dbSet.Select(p => new ProizvodModel
            {
                Id = p.Id,
                Ime = p.Ime,
                Tip = p.Tip,
                ProizvodjacId = p.ProizvodjacId,
                ProizvodjacIme = p.Proizvodjac.Ime
            }).ToList();

            return proizvodi;
        }

        public ProizvodModel GetProizvodModelById(int id)
        {
            var proizvod = dbSet.Select(p => new ProizvodModel
            {
                Id = p.Id,
                Ime = p.Ime,
                Tip = p.Tip,
                ProizvodjacId = p.ProizvodjacId,
                ProizvodjacIme = p.Proizvodjac.Ime
            }).FirstOrDefault(p => p.Id == id);

            return proizvod;
        }
    }
}
